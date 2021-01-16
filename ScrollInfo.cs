// <copyright file="ScrollInfo.cs" company="Pixel Precision LLC">
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
    public class ScrollInfo : SelectableInfo
    {
        public float scrollbarDim = 40.0f;
        public Sprite backplateSprite;
    }
}
