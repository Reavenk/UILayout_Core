using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleSeparator : Ele
        {
            UnityEngine.UI.Image img;

            public EleSeparator(Ele parent, Sprite sprite, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { 
                this._Create(parent, sprite, flags, size, name);
            }

            public EleSeparator(Ele parent, Sprite sprite, LFlag flags)
                : base(parent, flags)
            { 
                this._Create(parent, sprite, flags, new Vector2(-1.0f, -1.0f), "");
            }

            protected void _Create(Ele parent, Sprite sprite, LFlag flags, Vector2 size, string name)
            { 
                GameObject go = new GameObject("Separator_" + name);
                go.transform.SetParent(parent.GetContentRect());

                this.img = go.AddComponent<UnityEngine.UI.Image>();
                this.img.rectTransform.Short().Identity().AnchorTL().PivotTL().ZeroOffset();

                this.img.sprite = sprite;
                this.img.type = UnityEngine.UI.Image.Type.Sliced;
            }

            public override void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            {
                this.img.rectTransform.anchoredPosition = 
                    new Vector2(rectOffset.x, -rectOffset.y);

                this.img.rectTransform.sizeDelta = 
                    size;
            }

            public override bool CanHaveChildren()
            {
                return false;
            }
        }
    }
}