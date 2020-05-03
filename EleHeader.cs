using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleHeader : Ele
        {
            UnityEngine.UI.Image plate;
            UnityEngine.UI.Text text;

            public EleHeader(Ele parent, string text, Font font, Color fontColor, int fontPointSize, Sprite frame, PadRect padding, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { 
                this._Create(
                    parent, 
                    text, 
                    font, 
                    fontColor, 
                    fontPointSize, 
                    frame, 
                    padding, 
                    flags, 
                    size, 
                    name);
            }

            public EleHeader(Ele parent, string text, Font font, Color fontColor, int fontPointSize, Sprite frame, PadRect padding, LFlag flags)
                : base(parent, flags)
            {
                this._Create(
                    parent, 
                    text, 
                    font, 
                    fontColor, 
                    fontPointSize, 
                    frame, 
                    padding, 
                    flags, 
                    new Vector2(-1.0f, -1.0f), 
                    "");
            }

            protected void _Create(Ele parent, string text, Font font, Color fontColor, int fontPointSize, Sprite frame, PadRect padding, LFlag flags, Vector2 size, string name)
            {
                GameObject goPlate = new GameObject("HeaderPlate_" + name);
                goPlate.transform.SetParent(parent.GetContentRect());

                this.plate = goPlate.AddComponent<UnityEngine.UI.Image>();
                this.plate.rectTransform.Short().Identity().AnchorTL().PivotTL().ZeroOffset();

                this.plate.sprite = frame;
                this.plate.type = UnityEngine.UI.Image.Type.Sliced;

                this.padding = padding;

                GameObject goText = new GameObject("HeaderText_" + name);
                goText.transform.SetParent(this.plate.rectTransform);

                this.text = goText.AddComponent<UnityEngine.UI.Text>();
                this.text.rectTransform.Short().Identity().AnchorTL().PivotTL().ZeroOffset();

                this.text.font      = font;
                this.text.color     = fontColor;
                this.text.fontSize  = fontPointSize;
                this.text.text      = text;
            }

            protected override Vector2 ImplCalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            {
                Vector2 ret = new Vector2();

                if(this.text != null)
                {
                    TextGenerationSettings tgs = 
                        this.text.GetGenerationSettings(
                            new Vector2(
                                float.PositiveInfinity, 
                                float.PositiveInfinity));

                    TextGenerator tg = this.text.cachedTextGenerator;
                    ret.x = tg.GetPreferredWidth(this.text.text, tgs);
                    ret.y = tg.GetPreferredHeight(this.text.text, tgs);
                }

                if(this.HasChildren() == true)
                { 
                    Vector2 v2 = this.GetMinSize(cache, width);
                    ret.x = Mathf.Max(ret.x, v2.x);
                    ret.y = Mathf.Max(ret.y, v2.y);
                }

                ret.x += this.padding.width;
                ret.y += this.padding.height;
                return ret;
            }

            public override void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            {
                this.plate.rectTransform.anchoredPosition = new Vector2(rectOffset.x, -rectOffset.y);
                this.plate.rectTransform.sizeDelta = size;

                if (this.text != null)
                {
                    TextGenerationSettings tgs =
                        this.text.GetGenerationSettings(
                            new Vector2(
                                float.PositiveInfinity,
                                float.PositiveInfinity));

                    TextGenerator tg = this.text.cachedTextGenerator;
                    float textWidth = tg.GetPreferredWidth(this.text.text, tgs);
                    float textHeight = tg.GetPreferredHeight(this.text.text, tgs);

                    this.text.rectTransform.anchoredPosition = new Vector2(this.padding.left, -this.padding.top);
                    this.text.rectTransform.sizeDelta = new Vector2(textWidth, textHeight);
                }

                if(this.HasChildren() == true)
                { 
                    Vector2 internalSz = size;
                    internalSz.x -= this.padding.width;
                    internalSz.y -= this.padding.height;
                    base.Layout(cached, rectOffset, offset, internalSz);
                }
            }

            public override RectTransform GetRT()
            {
                return this.plate.rectTransform;
            }

            public override RectTransform GetContentRect()
            {
                return this.plate.rectTransform;
            }

            public override void Deconstruct()
            {
                GameObject.Destroy(this.plate.gameObject);
            }
        }
    }
}
