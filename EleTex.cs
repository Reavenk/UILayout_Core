// <copyright file="EleTex.cs" company="Pixel Precision LLC">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>William Leu</author>
// <date>12/28/2020</date>
// <summary></summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        /// <summary>
        /// UIL type for UI RawImages.
        /// </summary>
        public class EleTex : EleBaseRect
        {
            UnityEngine.UI.RawImage rawImg;

            public UnityEngine.UI.RawImage Image { get { return this.rawImg; } }

            public EleTex(EleBaseRect parent, Texture t, Vector2 size, string name = "")
                : base(parent, size, name)
            {
                this._Create(parent, t, size, name);
            }

            public EleTex(EleBaseRect parent, Texture t)
                : base(parent)
            {
                this._Create(parent, t, new Vector2(-1.0f, -1.0f), "");
            }

            protected void _Create(EleBaseRect parent, Texture t, Vector2 size, string name = "")
            {
                GameObject go = new GameObject("Texture_" + name);
                go.transform.SetParent(parent.GetContentRect(), false);

                this.rawImg = go.AddComponent<UnityEngine.UI.RawImage>();
                this.rawImg.rectTransform.RTQ().TopLeftAnchorsPivot().ZeroOffsets();

                this.rawImg.texture = t;
            }

            protected override float ImplCalcMinSizeWidth(Dictionary<Ele, float> cache)
            {
                float f = base.ImplCalcMinSizeWidth(cache);

                Texture t = this.rawImg.texture;
                if (t != null)
                    f = Mathf.Max(f, t.width, this.minSize.x);

                return f;
            }

            protected override Vector2 ImplCalcMinSize(
                Dictionary<Ele, Vector2> cache,
                Dictionary<Ele, float> widths,
                float width,
                bool collapsable = true)
            {
                Vector2 mindef = base.ImplCalcMinSize(cache, widths, width, collapsable);
                Vector2 min = this.minSize;

                Texture t = this.rawImg.texture;
                if (t != null)
                {
                    Vector2 spriteMin = new Vector2(t.width, t.height);

                    min.x = Mathf.Max(min.x, spriteMin.x);
                    min.y = Mathf.Max(min.y, spriteMin.y);
                }

                min.x = Mathf.Max(mindef.x, min.x);
                min.y = Mathf.Max(mindef.y, min.y);

                return min;
            }

            public override RectTransform RT => this.rawImg.rectTransform;

            public override Vector2 Layout(
                Dictionary<Ele, Vector2> cached,
                Dictionary<Ele, float> widths,
                Vector2 rectOffset,
                Vector2 offset,
                Vector2 size,
                bool collapsable = true)
            {
                return base.Layout(cached, widths, rectOffset, offset, size, collapsable);
            }
        }
    }
}