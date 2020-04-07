using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        public class EleButton : Ele
        { 
            UnityEngine.UI.Button button;
            UnityEngine.UI.Image plate;

            UnityEngine.UI.Text text = null;

            public EleButton(Ele parent, Font font, int fontSize, Color fontColor, string text, Sprite plateSprite, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { 
                this._Create(parent, font, fontSize, fontColor, text, plateSprite, flags, size, name);
            }

            public EleButton(Ele parent, Font font, int fontSize, Color fontColor, string text, Sprite plateSprite, LFlag flags)
                : base(parent, flags)
            { 
                this._Create(parent, font, fontSize, fontColor, text, plateSprite, flags, new Vector2(-1.0f, -1.0f), "");
            }

            public EleButton(Ele parent, Sprite plateSprite, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { 
                this._Create(parent, null, 0, Color.black, null, plateSprite, flags, size, name);
            }

            public EleButton(Ele parent, Sprite plateSprite, LFlag flags)
                : base(parent, flags)
            { 
                this._Create(parent, null, 0, Color.black, null, plateSprite, flags, new Vector2(-1.0f, -1.0f), "");
            }

            protected void _Create(Ele parent, Font font, int fontSize, Color fontColor, string text, Sprite plateSprite, LFlag flags, Vector2 size, string name)
            { 
                GameObject go = new GameObject("Button_" + name);

                go.transform.SetParent(parent.GetContentRect());
                go.Short().Identity();

                this.plate = go.AddComponent<UnityEngine.UI.Image>();
                this.button = go.AddComponent<UnityEngine.UI.Button>();
                this.plate.Short().PivotTL().AnchorTL();

                this.button.targetGraphic = this.plate;
                this.plate.sprite = plateSprite;
                this.plate.type = UnityEngine.UI.Image.Type.Sliced;

                if(string.IsNullOrEmpty(text) == false)
                { 
                    GameObject goChild = new GameObject("ButtonText_" + name);
                    goChild.transform.SetParent(go.transform);

                    this.text = goChild.AddComponent<UnityEngine.UI.Text>();
                    this.text.text                   = text;
                    this.text.font                   = font;
                    this.text.color                  = fontColor;
                    this.text.fontSize               = fontSize;
                    this.text.horizontalOverflow     = HorizontalWrapMode.Overflow;
                    this.text.alignment              = TextAnchor.LowerLeft;

                    this.text.rectTransform.Short().Identity().AnchorTL().PivotTL().ZeroOffset();
                }
            }

            public override RectTransform GetRT()
            {
                return this.plate.rectTransform;
            }

            protected override Vector2 ImplCalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            {
                Vector2 ret = Vector2.zero;

                if(this.text != null)
                { 
                    TextGenerationSettings tgs = 
                        this.text.GetGenerationSettings(
                            new Vector2(
                                float.PositiveInfinity, 
                                float.PositiveInfinity));

                    ret.x = this.text.cachedTextGenerator.GetPreferredWidth(this.text.text, tgs);
                    ret.y = this.text.cachedTextGenerator.GetPreferredHeight(this.text.text, tgs);
                }

                if(this.HasChildren() == true)
                { 
                    Vector2 sz = this.CalcMinSize_VerticalLayout(cache, width, 0.0f);
                    ret.x = Mathf.Max(ret.x, sz.x);
                    ret.y = Mathf.Max(ret.y, sz.y);
                }
                return ret + this.padding.dim;
            }

            public override void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            {
                this.plate.rectTransform.anchoredPosition = new Vector2(rectOffset.x, -rectOffset.y);
                this.plate.rectTransform.sizeDelta = size;

                if(this.text != null)
                {
                    Vector2 innerSz = size - this.padding.dim;

                    TextGenerationSettings tgs =
                        this.text.GetGenerationSettings(
                            new Vector2(
                                innerSz.x,
                                float.PositiveInfinity));

                    TextGenerator tg = this.text.cachedTextGenerator;
                    float width = tg.GetPreferredWidth(this.text.text, tgs);
                    float height = tg.GetPreferredHeight(this.text.text, tgs);

                    this.text.rectTransform.anchoredPosition = 
                        new Vector2(
                            this.padding.left + (innerSz.x - width)/2.0f,
                            -this.padding.top - (innerSz.y - height)/2.0f);

                    this.text.rectTransform.sizeDelta = 
                        new Vector2(
                            width, 
                            height);
                }

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
        }
    }
}