using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        public class EleText : Ele
        { 
            public UnityEngine.UI.Text text;
            bool wrap = false;

            public EleText(Ele parent, string text, bool wrap, Font font, Color color, int fontSize, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { 
                this._Create(parent, text, wrap, font, color, fontSize, flags, size, name);
            }

            public EleText(Ele parent, string text, bool wrap, Font font, Color color, int fontSize, LFlag flags)
                : base(parent, flags, new Vector2(-1.0f, -1.0f), "")
            {
                this._Create(parent, text, wrap, font, color, fontSize, flags, new Vector2(-1.0f, -1.0f), "");
            }

            protected void _Create(Ele parent, string text, bool wrap, Font font, Color color, int fontSize, LFlag flags, Vector2 size, string name)
            {
                GameObject go = new GameObject("Text_" + name);
                go.transform.SetParent(parent.GetContentRect());

                this.text = go.AddComponent<UnityEngine.UI.Text>();
                this.text.color = color;
                this.text.font = font;
                this.text.fontSize = fontSize;
                this.text.alignment = TextAnchor.UpperLeft;
                this.text.text = text;

                SetRTTopLeft(this.text.rectTransform);

                this.wrap = wrap;
                if (wrap == true)
                {
                    this.text.horizontalOverflow = HorizontalWrapMode.Wrap;
                }
                else
                {
                    this.text.horizontalOverflow = HorizontalWrapMode.Overflow;
                }

                this.text.rectTransform.Short().Identity();
            }

            public override void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            { 
                this.text.rectTransform.anchoredPosition = new Vector2(rectOffset.x, -rectOffset.y);
                this.text.rectTransform.sizeDelta = size;
            }

            protected override Vector2 ImplCalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            { 
                if(this.text.font == null)
                    return new Vector2(0.0f, 0.0f);

                TextGenerationSettings tgs = this.text.GetGenerationSettings(new Vector2(width, Mathf.Infinity));
                float x = this.text.cachedTextGeneratorForLayout.GetPreferredWidth(this.text.text, tgs);
                float y = this.text.cachedTextGeneratorForLayout.GetPreferredHeight(this.text.text, tgs);

                return new Vector2(x,y);
            }

            public override RectTransform GetRT()
            {
                return this.text.rectTransform;
            }

            public override RectTransform GetContentRect()
            {
                return this.text.rectTransform;
            }
        }
    }
}