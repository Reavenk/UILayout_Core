using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        [CreateAssetMenuAttribute(fileName = "UILFactory", menuName = "UIL Factory")]
        public class Factory : ScriptableObject
        {
            [System.Serializable]
            public struct TextAttrib
            { 
                public Font font;
                public int pointSize;
                public Color color;
            }

            public TextAttrib buttonTextAttrib;
            public Sprite buttonSprite;
            public Vector2 minButtonSize;
            public PadRect buttonPadding;

            public TextAttrib headerTextAttrib;
            public Sprite headerSprite;
            public Vector2 minHeaderSize;
            public PadRect headerPadding;

            public Sprite horizontalSplitterSprite;
            public Sprite verticalSplitterSprite;
            public Vector2 minSplitterSize;

            public Sprite horizontalScrollbarButtonSprite;
            public Sprite horizontalScrollbarSprite;
            public Sprite horizontalScrollbarThumbSprite;

            public Sprite verticalScrollbarButtonSprite;
            public Sprite verticalScrollbarSprite;
            public Sprite verticalScrollbarThumbSprite;

            public TextAttrib textTextAttrib;

            public EleButton CreateButton(Ele parent, string text, LFlag flags, Vector2 size, string name = "")
            { 
                EleButton ele = 
                    new EleButton(
                        parent, 
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        text,
                        this.buttonSprite,
                        flags,
                        size, 
                        name);

                ele.padding = this.buttonPadding;

                return ele;
            }

            public EleButton CreateButton(Ele parent, string text, LFlag flags)
            {
                EleButton ele =
                    new EleButton(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        text,
                        this.buttonSprite,
                        flags);

                ele.padding = this.buttonPadding;

                return ele;
            }


            public EleButton CreateButton(Ele parent, LFlag flags, Vector2 size, string name = "")
            { 
                EleButton ele = 
                    new EleButton(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        null,
                        this.buttonSprite,
                        flags,
                        size,
                        name);

                ele.padding = this.buttonPadding;

                return ele;
            }

            public EleButton CreateButton(Ele parent, LFlag flags)
            {
                EleButton ele =
                    new EleButton(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        null,
                        this.buttonSprite,
                        flags);

                ele.padding = this.buttonPadding;

                return ele;
            }

            public EleButton CreateButton(Ele parent, Sprite sprite, LFlag flags, Vector2 size, string name = "")
            {
                EleButton ele = 
                    new EleButton(
                        parent,
                        sprite,
                        flags,
                        size,
                        name);

                ele.padding = this.buttonPadding;

                return ele;
            }

            public EleButton CreateButton(Ele parent, Sprite sprite, LFlag flags)
            {
                EleButton ele =
                    new EleButton(
                        parent,
                        sprite,
                        flags);

                ele.padding = this.buttonPadding;

                return ele;
            }

            public EleHeader CreateHeader(Ele parent, string text, LFlag flags)
            { 
                EleHeader ele = 
                    new EleHeader(parent, text , this.headerTextAttrib.font, this.headerTextAttrib.color, this.headerTextAttrib.pointSize, this.headerSprite, this.headerPadding, flags);

                ele.padding = this.headerPadding;
                ele.minSize = this.minHeaderSize;

                return ele;
            }

            public EleHeader CreateExpandedHeader(Ele parent, string text, LFlag flags)
            {
                EleHeader ele =
                    new EleHeader(
                        parent, 
                        text, 
                        this.headerTextAttrib.font, 
                        this.headerTextAttrib.color, 
                        this.headerTextAttrib.pointSize, 
                        this.headerSprite, 
                        this.headerPadding, 
                        flags|LFlag.GrowHoriz);

                ele.padding = this.headerPadding;
                ele.minSize = this.minHeaderSize;

                return ele;
            }

            public EleSeparator CreateSeparator(Ele parent, LFlag flags, Vector2 size)
            { 
                EleSeparator ele = 
                    new EleSeparator(
                        parent, 
                        this.horizontalSplitterSprite, 
                        flags, 
                        size, 
                        "");

                return ele;
            }

            public EleSeparator CreateHorizontalSeparator(Ele parent)
            { 
                EleSeparator ele = 
                    new EleSeparator(
                        parent, 
                        this.horizontalSplitterSprite, 
                        LFlag.GrowHoriz);

                ele.minSize = this.minSplitterSize;

                return ele;
            }

            public EleSeparator CreateVerticalSeparator(Ele parent)
            { 
                EleSeparator ele = 
                    new EleSeparator(
                        parent, 
                        this.horizontalSplitterSprite, 
                        LFlag.GrowVert);

                ele.minSize = this.minSplitterSize;

                return ele;
            }

            public EleText CreateText(Ele parent, string text, bool wrap, LFlag flags, Vector2 size, string name = "")
            { 
                EleText ele = 
                    new EleText(
                        parent, 
                        text,
                        wrap, 
                        this.textTextAttrib.font, 
                        this.textTextAttrib.color, 
                        this.textTextAttrib.pointSize, 
                        flags, 
                        size, 
                        name);

                return ele;
            }

            public EleText CreateText(Ele parent, string text, bool wrap, LFlag flags)
            {
                EleText ele = 
                    new EleText(
                        parent,
                        text,
                        wrap,
                        this.textTextAttrib.font,
                        this.textTextAttrib.color,
                        this.textTextAttrib.pointSize,
                        flags);

                return ele;
            }

            public EleImg CreateImage(Ele parent, Sprite sprite, LFlag flags, Vector2 size, string name = "")
            { 
                EleImg ret = new EleImg(parent, sprite, flags, size, name);
                return ret;
            }
            
            public EleImg CreateImage(Ele parent, Sprite sprite, LFlag flags, string name = "")
            { 
                EleImg ret = new EleImg(parent, sprite, flags);
                return ret;
            }
            
            //public EleImg CreateHorizontalSpacer(Ele parent, int flags, Vector2 size)
            //{ 
            //}
            //
            //public EleImg CreateVerticalSpacer(Ele parent, int flags, Vector2 size)
            //{ 
            //}
            //
            //public EleScrollView CreateScrollView(Ele parent)
            //{ 
            //}
            //
            //public static CreateBoxSizer(Ele parent)
            //{ 
            //}
        }
    }
}