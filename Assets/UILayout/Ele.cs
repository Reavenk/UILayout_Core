using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        [System.Flags]
        public enum LFlag
        { 
            GrowHoriz           = 1 << 0,
            GrowVert            = 1 << 2,
            Grow                = GrowHoriz | GrowVert,
            AlignLeft           = 1 << 3,
            AlignRight          = 1 << 4,
            AlignTop            = 1 << 5,
            AlignBot            = 1 << 6,
            AlignVertCenter     = 1 << 7,
            AlignHorizCenter    = 1 << 8,
            AlignCenter         = AlignVertCenter | AlignHorizCenter
        }

        public enum Direction
        { 
            Horiz,
            Vert
        }

        public abstract class Ele
        { 
            Ele parent;
            Ele Parent {get { return this.parent; } }

            List<Ele> children = null;

            public Vector2 size = new Vector2(-1.0f, -1.0f);
            public Vector2 minSize = Vector2.zero;
            public LFlag flags = 0;

            // Applies to all widgets
            public PadRect border = new PadRect();

            // Applies only to some, and how they add space between their outer 
            // bounds and their children.
            public PadRect padding = new PadRect();

            float proportion = 0.0f;

            string name = "";
            public string Name {get{return this.name; } }

            bool active = true;
            public virtual bool Active 
            {
                get{ return this.active; } 
                set
                { 
                    RectTransform rt = this.GetRT();
                    if(rt != null)
                        rt.gameObject.SetActive(value);

                    this.active = value; 
                } 
            }

            public Ele(Ele parent, LFlag flags, Vector2 size, string name = "")
            { 
                this.parent = parent;
                this.flags = flags;
                this.size = size;
                this.name = name;

                if(parent != null)
                { 
                    parent.AddChild(this);
                }
            }

            public Ele(Ele parent, LFlag flags)
            {
                this.parent = parent;
                this.flags = flags;

                if(this.parent != null)
                    this.parent.AddChild(this);

                this.size = new Vector2(-1.0f, -1.0f);
                this.name = "";
            }

            public bool HasChildren()
            { 
                return 
                    this.children != null && 
                    this.children.Count > 0;
            }

            public virtual bool CanHaveChildren()
            { 
                return true;
            }

            public virtual bool AddChild(Ele ele)
            { 
                if(this.CanHaveChildren() == false)
                    return false;

                if(this.GetContentRect() == null)
                    return false;

                if(this.children == null)
                    this.children = new List<Ele>();

                this.children.Add(ele);
                return true;
            }

            public Vector2 GetMinSize(Dictionary<Ele, Vector2> cache, float width)
            { 
                Vector2 v2;
                if(cache.TryGetValue(this, out v2) == true)
                    return v2;

                v2 = this.CalcMinSize(cache, width);
                cache.Add(this, v2);
                return v2;
            }

            public Vector2 CalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            { 
                Vector2 ret = ImplCalcMinSize(cache, width);
                ret.x = Mathf.Max(ret.x, this.minSize.x);
                ret.y = Mathf.Max(ret.y, this.minSize.y);
                return ret;
            }

            protected virtual Vector2 ImplCalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            { 
                return this.CalcMinSize_VerticalLayout(cache, width, 0.0f);
            }

            public virtual void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            {
               this.Layout_VerticalLayout(cached, 0.0f, rectOffset, offset, size);
            }

            
            public virtual RectTransform GetRT()
            { 
                return null;
            }

            public virtual RectTransform GetParentRect()
            {
                if(this.parent == null)
                    return null;

                return this.parent.GetContentRect();
            }

            public virtual RectTransform GetContentRect()
            { 
                RectTransform crt = this.GetRT();
                if(crt != null)
                    return crt;

                return this.GetParentRect(); 
            }


            protected Vector2 CalcMinSize_VerticalLayout(Dictionary<Ele, Vector2> cache, float separation, float width)
            { 
                Vector2 max = Vector2.zero;
                if(this.HasChildren() == false)
                    return Vector2.zero;

                bool atleastone = false;
                foreach(Ele e in this.children)
                { 
                    if(e.Active == false)
                        continue;

                    Vector2 cminsz = e.GetMinSize(cache, width);
                    if(atleastone == true)
                        max.y += separation;

                    max.x = Mathf.Max(cminsz.x, max.x);
                    max.y += cminsz.y;

                    atleastone = true;
                }

                return max;
            }

            protected void Layout_VerticalLayout(Dictionary<Ele, Vector2> cached, float separation, Vector2 rectOffset, Vector2 offset, Vector2 size)
            { 
                float totalHeight = 0.0f;
                float totalProportion = 0.0f;

                if(this.HasChildren() == false) 
                    return;

                // Collect information
                foreach(Ele e in this.children)
                { 
                    if(e.Active == false)
                        continue;

                    totalProportion += e.proportion;
                    totalHeight += e.GetMinSize(cached, size.x).y;
                }

                float excessHeight = Mathf.Max(size.y - totalHeight, 0.0f);

                float fyOffset = 0.0f;
                // Delegate layout commands
                foreach(Ele e in this.children)
                { 
                    if(e.Active == false)
                        continue;

                    Vector2 celesz = e.GetMinSize(cached, size.x);
                    float propalloc = 0.0f;

                    if(e.proportion != 0.0f)
                        propalloc += excessHeight * (e.proportion/totalProportion);

                    float eleHeight = celesz.y + propalloc;

                    Vector2 localPos = Vector2.zero;
                    Vector2 localSz = celesz;

                    if((e.flags & LFlag.GrowHoriz) != 0)
                        localSz.x = size.x;

                    if((e.flags & LFlag.GrowVert) != 0)
                        localSz.y = eleHeight;

                    if((e.flags & LFlag.AlignLeft) != 0)
                    { } // Do nothing, already left aligned
                    else if((e.flags & LFlag.AlignRight) != 0)
                        localPos.x = size.x - localSz.x;
                    else if((e.flags & LFlag.AlignHorizCenter) != 0)
                        localPos.x = (size.x - localSz.x)/2.0f;

                    if((e.flags & LFlag.AlignTop) != 0)
                    { }// Do nothing, already top aligned
                    else if((e.flags & LFlag.AlignBot) != 0)
                        localPos.y += eleHeight - size.y;
                    else if((e.flags & LFlag.AlignVertCenter) != 0)
                        localPos.y += (eleHeight - size.y) / 2.0f;

                    e.Layout(
                        cached, 
                        new Vector2(rectOffset.x + localPos.x, rectOffset.y + localPos.y + fyOffset), 
                        new Vector2(offset.x + localPos.x, offset.y + localPos.y + fyOffset),
                        localSz);

                    fyOffset += eleHeight;
                }
            }

            protected Vector2 CalcMinSize_HorizontalLayout(Dictionary<Ele, Vector2> cache, float separation, float width)
            { 
                Vector2 max = Vector2.zero;
                if(this.HasChildren() == false)
                    return Vector2.zero;

                bool atleastone = false;
                foreach(Ele e in this.children)
                { 
                    if(e.Active == false)
                        continue;

                    Vector2 cminsz = e.GetMinSize(cache,width);
                    if(atleastone == true)
                        max.x += separation;

                    max.x += cminsz.x;
                    max.y = Mathf.Max(cminsz.y, max.y);

                    atleastone = true;
                }

                return max;
            }

            protected void Layout_HorizontalLayout(Dictionary<Ele, Vector2> cache, float separation, Vector2 rectOffset, Vector2 offset, Vector2 size)
            { 
            }

            public static void SetRTTopLeft(RectTransform rt)
            { 
                rt.anchorMin = new Vector2(0.0f, 1.0f);
                rt.anchorMax = new Vector2(0.0f, 1.0f);
                rt.pivot = new Vector2(0.0f, 1.0f);
                rt.offsetMin = new Vector2(0.0f, 0.0f);
                rt.offsetMax = new Vector2(0.0f, 0.0f);
            }

            public virtual void Deconstruct()
            { 
                this.ClearChildren();
            }

            public void ClearChildren()
            { 
                if(this.children != null)
                { 
                    foreach(Ele e in this.children)
                        e.Deconstruct();
                }

                this.children.Clear();
            }

            public void Layout()
            { 
                Dictionary<Ele, Vector2> cache = new Dictionary<Ele, Vector2>();

                RectTransform rt = this.GetRT();
                Rect r = rt.rect;

                Vector2 minSz = this.GetMinSize(cache, r.width);
            }
        }
    }
}
