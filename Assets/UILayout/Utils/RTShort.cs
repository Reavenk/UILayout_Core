using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        public struct RTShort
        { 
            public RectTransform rt;

            public RTShort(RectTransform rt)
            { 
                this.rt = rt;
            }

            public RTShort Anchor(Vector2 min, Vector2 max)
            { 
                this.rt.anchorMin = min;
                this.rt.anchorMax = max;
                return this;
            }

            public RTShort Anchor(float minx, float miny, float maxx, float maxy)
            { 
                this.rt.anchorMin = new Vector2(minx, miny);
                this.rt.anchorMax = new Vector2(maxx, maxy);
                return this;
            }

            public RTShort ZeroAnchor()
            { 
                this.rt.anchorMin = Vector2.zero;
                this.rt.anchorMax = Vector2.zero;
                return this;
            }

            public RTShort AnchorZero()
            { 
                return this.ZeroAnchor();
            }

            public RTShort AnchorTL()
            { 
                this.rt.anchorMin = new Vector2(0.0f, 1.0f);
                this.rt.anchorMax = new Vector2(0.0f, 1.0f);
                return this;
            }

            public RTShort Offset(Vector2 pos)
            {
                this.rt.offsetMin = pos;
                this.rt.offsetMax = pos;
                return this;
            }

            public RTShort Offset(float x, float y)
            { 
                this.rt.offsetMin = new Vector2(x, y);
                this.rt.offsetMax = new Vector2(x, y);
                return this;
            }

            public RTShort Offset(Vector2 min, Vector2 max)
            { 
                this.rt.offsetMin = min;
                this.rt.offsetMax = max;
                return this;
            }

            public RTShort Offset(float minx, float miny, float maxx, float maxy)
            { 
                this.rt.offsetMin = new Vector2(minx, miny);
                this.rt.offsetMax = new Vector2(maxx, maxy);
                return this;
            }

            public RTShort ZeroOffset()
            { 
                this.rt.offsetMin = Vector2.zero;
                this.rt.offsetMax = Vector2.zero;
                return this;
            }

            public RTShort OffsetZero()
            { 
                return this.ZeroOffset();
            }

            public RTShort Pivot(Vector2 pivot)
            {
                this.rt.pivot = pivot;
                return this;
            }

            public RTShort Pivot(float x, float y)
            { 
                this.rt.pivot = new Vector2(x, y);
                return this;
            }

            public RTShort ZeroPivot()
            { 
                this.rt.pivot = Vector2.zero;
                return this;
            }

            public RTShort PivotZero()
            { 
                this.rt.pivot = Vector2.zero;
                return this;
            }


            public RTShort PivotCenter()
            { 
                this.rt.pivot = new Vector2(0.5f, 0.5f);
                return this;
            }

            public RTShort PivotTL()
            { 
                this.rt.pivot = new Vector2(0.0f, 1.0f);
                return this;
            }

            public RTShort PivotRT()
            { 
                this.rt.pivot = new Vector2(1.0f, 1.0f);
                return this;
            }

            public RTShort PivotBL()
            { 
                this.rt.pivot = new Vector2(0.0f, 0.0f);
                return this;
            }

            public RTShort PivotBR()
            { 
                this.rt.pivot = new Vector2(1.0f, 0.0f);
                return this;
            }

            public RTShort AnchorPos(Vector2 v2)
            { 
                this.rt.anchoredPosition = v2;
                return this;
            }

            public RTShort AnchorPos(float x, float y)
            { 
                this.rt.anchoredPosition = new Vector2(x,y);
                return this;
            }

            public RTShort SizeDelta(Vector2 v2)
            { 
                this.rt.sizeDelta = v2;
                return this;
            }

            public RTShort SizeDelta(float x, float y)
            { 
                this.rt.sizeDelta = new Vector2(x, y);
                return this;
            }

            public RTShort Identity()
            { 
                this.rt.localPosition   = Vector3.zero;
                this.rt.localRotation   = Quaternion.identity;
                this.rt.localScale      = Vector3.one;

                return this;
            }

            public RTShort SetParent(RectTransform parent)
            {
                this.rt.SetParent(parent);
                return this;
            }

            public RTShort SetParentAndIdentity(RectTransform parent)
            { 
                this.rt.SetParent(parent);
                return this.Identity();
            }
        }

        public static class RTShortUtil
        { 
            public static RTShort Short(this GameObject go)
            { 
                RectTransform rt = go.GetComponent<RectTransform>();
                if(rt != null)
                    return new RTShort(rt);

                rt = go.AddComponent<RectTransform>();
                return new RTShort(rt);
            }

            public static RTShort Short(this RectTransform rt)
            { 
                return new RTShort(rt);
            }

            public static RTShort Short(this UnityEngine.UI.Graphic g)
            { 
                return new RTShort(g.rectTransform);
            }
        }
    }
}