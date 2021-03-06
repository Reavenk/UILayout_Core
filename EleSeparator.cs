﻿// <copyright file="EleSeperator.cs" company="Pixel Precision LLC">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>William Leu</author>
// <date>09/25/2020</date>
// <summary></summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.UIL
{
    public class EleSeparator : EleBaseRect
    {
        UnityEngine.UI.Image img;

        public EleSeparator(EleBaseRect parent, Sprite sprite, Vector2 size, string name = "")
            : base(parent, size, name)
        { 
            this._Create(parent, sprite, size, name);
        }

        public EleSeparator(EleBaseRect parent, Sprite sprite, LFlag flags)
            : base(parent)
        { 
            this._Create(parent, sprite, new Vector2(-1.0f, -1.0f), "");
        }

        protected void _Create(EleBaseRect parent, Sprite sprite, Vector2 size, string name)
        { 
            GameObject go = new GameObject("Separator_" + name);
            go.transform.SetParent(parent.GetContentRect());

            this.img = go.AddComponent<UnityEngine.UI.Image>();
            this.img.rectTransform.RTQ().Identity().TopLeftAnchorsPivot().ZeroOffsets();

            this.img.sprite = sprite;
            this.img.type = UnityEngine.UI.Image.Type.Sliced;
        }

        public override RectTransform RT => this.img.rectTransform;

        public override Vector2 Layout(
            Dictionary<Ele, Vector2> cached,
            Dictionary<Ele, float> widths, 
            Vector2 rectOffset, 
            Vector2 offset, 
            Vector2 size,
            bool collapsable = true)
        {
            return base.Layout(cached, widths, rectOffset, offset, size);
        }

        public override bool CanHaveChildren()
        {
            return false;
        }
    }
}