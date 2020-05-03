using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        public class EleImg : Ele
        { 
            UnityEngine.UI.Image img;

            public EleImg(Ele parent, Sprite sprite, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { 
                this._Create(parent, sprite, flags, size, name);
            }

            public EleImg(Ele parent, Sprite sprite, LFlag flags)
                : base(parent, flags)
            { 
                this._Create(parent, sprite, flags, new Vector2(-1.0f, -1.0f), "");
            }

            protected void _Create(Ele parent, Sprite sprite, LFlag flags, Vector2 size, string name = "")
            { 
                GameObject go = new GameObject("Image_" + name);
                go.transform.SetParent(parent.GetContentRect());

                this.img = go.AddComponent<UnityEngine.UI.Image>();
                this.img.rectTransform.Short().Identity().AnchorTL().PivotTL().ZeroOffset();

                this.img.sprite = sprite;
                this.img.type = UnityEngine.UI.Image.Type.Simple;
            }

            protected override Vector2 ImplCalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            {
                Vector2 ret = new Vector2(0.0f, 0.0f);

                if(this.size.x >= 0.0f || this.size.y >= 0.0f)
                    ret = this.size;
                else if(this.img.sprite != null)
                {
                    Rect r = this.img.sprite.rect;

                    ret = 
                        new Vector2(
                            r.width, 
                            r.height);
                }

                if(this.HasChildren() == true)
                { 
                    Vector2 chsz = this.CalcMinSize_VerticalLayout(cache, 0.0f, width);
                    ret.x = Mathf.Max(ret.x, chsz.x);
                    ret.y = Mathf.Max(ret.y, chsz.y);
                }

                return ret;
            }

            public override void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            {
                this.img.rectTransform.anchoredPosition = new Vector2(rectOffset.x, -rectOffset.y);
                this.img.rectTransform.sizeDelta = size;

                if(this.HasChildren() == true)
                {
                    this.Layout_VerticalLayout(
                        cached, 
                        0.0f, 
                        rectOffset, 
                        offset, 
                        size);
                }
            }

            public override RectTransform GetRT()
            {
                return this.img.rectTransform;
            }

            public override RectTransform GetContentRect()
            {
                return this.img.rectTransform;
            }
        }
    }
}