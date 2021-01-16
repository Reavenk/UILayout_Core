// <copyright file="TextAttrib.cs" company="Pixel Precision LLC">
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
    [System.Serializable]
    public class TextAttrib
    {
        public Font font;
        public int fontSize = 14;
        public Color color = Color.black;

        public void Apply(UnityEngine.UI.Text text)
        {
            text.font = this.font;
            text.fontSize = this.fontSize;
            text.color = this.color;
        }

        public TextAttrib Clone()
        {
            TextAttrib ret = new TextAttrib();
            ret.font = this.font;
            ret.fontSize = this.fontSize;
            ret.color = this.color;

            return ret;
        }
    }
}