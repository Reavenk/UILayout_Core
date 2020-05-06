using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        public class EleText : EleBaseRect
        { 
            public UnityEngine.UI.Text text;
            bool wrap = false;

            public EleText(EleBaseRect parent, string text, bool wrap, Font font, Color color, int fontSize, Vector2 size, string name = "")
                : base(parent, size, name)
            { 
                this._Create(parent, text, wrap, font, color, fontSize, size, name);
            }

            public EleText(EleBaseRect parent, string text, bool wrap, Font font, Color color, int fontSize)
                : base(parent, new Vector2(-1.0f, -1.0f), "")
            {
                this._Create(parent, text, wrap, font, color, fontSize, new Vector2(-1.0f, -1.0f), "");
            }

            protected void _Create(EleBaseRect parent, string text, bool wrap, Font font, Color color, int fontSize, Vector2 size, string name)
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

            public override Vector2 Layout(
                Dictionary<Ele, Vector2> cached,
                Dictionary<Ele, float> widths,
                Vector2 rectOffset, 
                Vector2 offset, 
                Vector2 size)
            { 
                Vector2 ret = base.Layout(cached, widths, rectOffset, offset, size);
                return ret;
            }

            protected override float ImplCalcMinSizeWidth(Dictionary<Ele, float> cache)
            {
                if (this.text.font == null)
                    return 0.0f;

                TextGenerationSettings tgs = this.text.GetGenerationSettings(new Vector2(0.0f, Mathf.Infinity));
                TextGenerator tg = this.text.cachedTextGeneratorForLayout;

                float ret = tg.GetPreferredWidth(this.text.text, tgs);
                return Mathf.Ceil(ret) + 1.0f;
            }

            protected override Vector2 ImplCalcMinSize(
                Dictionary<Ele, Vector2> cache, 
                Dictionary<Ele, float> widths, 
                float width)
            { 
                if(this.text.font == null)
                    return new Vector2(0.0f, 0.0f);

                TextGenerationSettings tgs = this.text.GetGenerationSettings(new Vector2(width, Mathf.Infinity));
                TextGenerator tg = this.text.cachedTextGeneratorForLayout;

                float x = Mathf.Ceil(tg.GetPreferredWidth(this.text.text, tgs)) + 1.0f;
                float y = Mathf.Ceil(tg.GetPreferredHeight(this.text.text, tgs)) + 1.0f;

                return new Vector2(x,y);
            }

            public override RectTransform RT
            {
                get{ return this.text.rectTransform; }
            }
        }
    }
}