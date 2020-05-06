﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleInput : EleBaseRect
        { 
            public UnityEngine.UI.InputField input = null;
            public UnityEngine.UI.Text text = null;
            public UnityEngine.UI.Text placeholder = null;
            public PadRect border = new PadRect(10.0f, 10.0f, 10.0f, 10.0f);
            RectTransform rt;

            public override RectTransform RT => this.rt;

            public EleInput(EleBaseRect parent, string text, Font font, Color fontColor, int pointSize, bool multiline, Sprite plate, PadRect padding, Vector2 size, string name = "")
                : base(parent, size, name)
            { 
                this._Create(
                    parent, 
                    text, 
                    font, 
                    fontColor, 
                    pointSize, 
                    multiline, 
                    plate, 
                    padding, 
                    size, 
                    name);
            }

            public EleInput(EleBaseRect parent, string text, Font font, Color fontColor, int pointSize, bool multiline, Sprite plate, float padding, Vector2 size, string name = "")
                : base(parent, size, name)
            { 
                this._Create(
                    parent, 
                    text, 
                    font, 
                    fontColor, 
                    pointSize, 
                    multiline, 
                    plate, 
                    new PadRect(padding), 
                    size, 
                    name);
            }

            protected void _Create(EleBaseRect parent, string text, Font font, Color fontColor, int pointSize, bool multiline, Sprite plate, PadRect padding, Vector2 size, string name)
            { 
                this.border = padding;

                GameObject go = new GameObject("Input_" + name);
                go.transform.SetParent(parent.GetContentRect());
                go.transform.localRotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
                UnityEngine.UI.Image img = go.AddComponent<UnityEngine.UI.Image>();
                img.RTQ().TopLeftAnchorsPivot();
                img.sprite = plate;
                img.type = UnityEngine.UI.Image.Type.Sliced;

                GameObject goText = new GameObject("InputText_" + name);
                goText.transform.SetParent(go.transform);
                goText.transform.localRotation = Quaternion.identity;
                goText.transform.localPosition = Vector3.zero;
                UnityEngine.UI.Text txt = goText.AddComponent<UnityEngine.UI.Text>();
                txt.RTQ().TopLeftAnchorsPivot();

                GameObject goPlaceholder = new GameObject("InputPlaceholder_" + name);
                goPlaceholder.transform.SetParent(go.transform);
                goPlaceholder.transform.localRotation = Quaternion.identity;
                goPlaceholder.transform.localPosition = Vector3.zero;
                UnityEngine.UI.Text txtPlace = goPlaceholder.AddComponent<UnityEngine.UI.Text>();
                txtPlace.RTQ().TopLeftAnchorsPivot();

                this.input = go.AddComponent<UnityEngine.UI.InputField>();
                this.input.textComponent = txt;
                this.input.targetGraphic = img;
                this.input.placeholder = txtPlace;
                this.rt = go.GetComponent<RectTransform>();
                this.placeholder = txtPlace;
                this.text = txt;
                this.text.color = fontColor;
                this.text.font = font;
                this.text.fontSize = pointSize;
                this.placeholder.color = new Color(fontColor.r, fontColor.g, fontColor.b, fontColor.a * 0.5f);
                this.placeholder.font = font;
                this.placeholder.fontSize = pointSize;

                this.input.lineType = 
                    multiline ? 
                        UnityEngine.UI.InputField.LineType.MultiLineNewline : 
                        UnityEngine.UI.InputField.LineType.SingleLine;
            }

            public override bool CanHaveChildren()
            {
                return false;
            }

            protected override float ImplCalcMinSizeWidth(Dictionary<Ele, float> cache)
            { 
                return this.border.width;
            }

            protected override Vector2 ImplCalcMinSize(
                Dictionary<Ele, Vector2> cache, 
                Dictionary<Ele, float> widths, 
                float width)
            {
                TextGenerator tg = this.text.cachedTextGenerator;
                TextGenerationSettings tgs = 
                    this.text.GetGenerationSettings(
                        new Vector2(
                            float.PositiveInfinity, 
                            float.PositiveInfinity));

                float h = tg.GetPreferredHeight("M", tgs);

                return new Vector2(this.border.width, this.border.height + h);
            }

            public override Vector2 Layout(
                Dictionary<Ele, Vector2> cached, 
                Dictionary<Ele, float> widths, 
                Vector2 rectOffset, 
                Vector2 offset, 
                Vector2 size)
            {
                //return base.Layout(cached, widths, rectOffset, offset, size);
                base.Layout(cached, widths, rectOffset, offset, size);

                this.text.RTQ().
                    ExpandParentFlush().
                    OffsetMin( this.border.left, this.border.bot).
                    OffsetMax(-this.border.right, -this.border.top);

                this.placeholder.RTQ().
                    ExpandParentFlush().
                    OffsetMin(this.border.left, this.border.bot).
                    OffsetMax(-this.border.right, -this.border.top);

                return size;
            }
        }
    }
}