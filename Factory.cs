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

            public UnityEngine.UI.Button.Transition buttonTransition = UnityEngine.UI.Selectable.Transition.ColorTint;
            public UnityEngine.UI.SpriteState buttonSpriteState = new UnityEngine.UI.SpriteState();
            public Color buttonFontColor = Color.black;
            public Font buttonFont;
            public int buttonFontSize = 14;

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

            public Sprite inputSprite;
            public PadRect inputPadding;
            public int inputFontSize = 14;
            public Font inputFont;
            public Color inputFontColor = Color.black;

            internal UnityEngine.Events.UnityAction<UnityEngine.UI.Button> onCreateButton = null;

            void ApplyButtonStyle(UnityEngine.UI.Button button, UnityEngine.UI.Text text, bool callback = false)
            {
                if(text != null)
                { 
                    text.fontSize   = this.buttonFontSize;
                    text.font       = this.buttonFont;
                    text.color      = this.buttonFontColor;

                    text.rectTransform.offsetMin += new Vector2(this.buttonPadding.left, this.buttonPadding.bot);
                    text.rectTransform.offsetMax += new Vector2(-this.buttonPadding.right, -this.buttonPadding.top);
                }

                button.spriteState = this.buttonSpriteState;
                button.transition = this.buttonTransition;
            }

            void ApplyButtonStyle<BtnTy>(EleGenButton<BtnTy> ele)
                where BtnTy : UnityEngine.UI.Button

            { 
                ele.border = this.buttonPadding;
                this.ApplyButtonStyle(ele.Button, ele.text, true);
            }

            public EleGenButton<BtnTy> CreateButton<BtnTy>(EleBaseRect parent, string text, Vector2 size, string name = "")
                where BtnTy : UnityEngine.UI.Button
            {
                EleGenButton<BtnTy> ele =
                    new EleGenButton<BtnTy>(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        text,
                        this.buttonSprite,
                        size,
                        name);

                ele.border = this.buttonPadding;

                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleButton CreateButton(EleBaseRect parent, string text, Vector2 size, string name = "")
            { 
                EleButton ele = 
                    new EleButton(
                        parent, 
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        text,
                        this.buttonSprite,
                        size, 
                        name);



                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleGenButton<BtnTy> CreateButton<BtnTy>(EleBaseRect parent, string text)
                where BtnTy : UnityEngine.UI.Button
            {
                EleGenButton<BtnTy> ele =
                    new EleGenButton<BtnTy>(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        text,
                        this.buttonSprite);

                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleButton CreateButton(EleBaseRect parent, string text)
            {
                EleButton ele =
                    new EleButton(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        text,
                        this.buttonSprite);

                this.ApplyButtonStyle(ele);
                return ele;
            }


            public EleButton CreateButton(EleBaseRect parent, Vector2 size, string name = "")
            { 
                EleButton ele = 
                    new EleButton(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        null,
                        this.buttonSprite,
                        size,
                        name);

                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleButton CreateButton(EleBaseRect parent)
            {
                EleButton ele =
                    new EleButton(
                        parent,
                        this.buttonTextAttrib.font,
                        this.buttonTextAttrib.pointSize,
                        this.buttonTextAttrib.color,
                        null,
                        this.buttonSprite);

                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleButton CreateButton(EleBaseRect parent, Sprite sprite, Vector2 size, string name = "")
            {
                EleButton ele = 
                    new EleButton(
                        parent,
                        sprite,
                        size,
                        name);

                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleButton CreateButton(EleBaseRect parent, Sprite sprite)
            {
                EleButton ele =
                    new EleButton(
                        parent,
                        sprite);

                this.ApplyButtonStyle(ele);
                return ele;
            }

            public EleHeader CreateHeader(EleBaseRect parent, string text)
            { 
                EleHeader ele = 
                    new EleHeader(
                        parent, 
                        text, 
                        this.headerTextAttrib.font, 
                        this.headerTextAttrib.color, 
                        this.headerTextAttrib.pointSize, 
                        this.headerSprite, 
                        this.headerPadding);

                ele.border = this.headerPadding;
                ele.minSize = this.minHeaderSize;

                return ele;
            }

            public EleBoxSizer HorizontalSizer(EleBaseRect parent)
            {
                EleBoxSizer bs = new EleBoxSizer(parent, Direction.Horiz);
                return bs;
            }

            public EleBoxSizer VerticalSizer(EleBaseRect parent)
            { 
                EleBoxSizer bs = new EleBoxSizer(parent, Direction.Vert);
                return bs;
            }

            public EleBoxSizer HorizontalSizer(EleBaseSizer parent, float proportion, LFlag flags)
            {
                EleBoxSizer bs = new EleBoxSizer(parent, Direction.Horiz, proportion, flags);
                return bs;
            }

            public EleBoxSizer VerticalSizer(EleBaseSizer parent, float proportion, LFlag flags)
            {
                EleBoxSizer bs = new EleBoxSizer(parent, Direction.Vert, proportion, flags);
                return bs;
            }

            public EleSeparator CreateSeparator(EleBaseRect parent, Vector2 size)
            { 
                EleSeparator ele = 
                    new EleSeparator(
                        parent, 
                        this.horizontalSplitterSprite, 
                        size, 
                        "");

                return ele;
            }

            public EleSeparator CreateHorizontalSeparator(EleBaseRect parent)
            { 
                EleSeparator ele = 
                    new EleSeparator(
                        parent, 
                        this.horizontalSplitterSprite, 
                        LFlag.GrowHoriz);

                ele.minSize = this.minSplitterSize;

                return ele;
            }

            public EleSeparator CreateVerticalSeparator(EleBaseRect parent)
            { 
                EleSeparator ele = 
                    new EleSeparator(
                        parent, 
                        this.horizontalSplitterSprite, 
                        LFlag.GrowVert);

                ele.minSize = this.minSplitterSize;

                return ele;
            }

            public EleText CreateText(EleBaseRect parent, string text, bool wrap, Vector2 size, string name = "")
            { 
                EleText ele = 
                    new EleText(
                        parent, 
                        text,
                        wrap, 
                        this.textTextAttrib.font, 
                        this.textTextAttrib.color, 
                        this.textTextAttrib.pointSize, 
                        size, 
                        name);

                return ele;
            }

            public EleText CreateText(EleBaseRect parent, string text, bool wrap)
            {
                EleText ele = 
                    new EleText(
                        parent,
                        text,
                        wrap,
                        this.textTextAttrib.font,
                        this.textTextAttrib.color,
                        this.textTextAttrib.pointSize);

                return ele;
            }

            public EleImg CreateImage(EleBaseRect parent, Sprite sprite, Vector2 size, string name = "")
            { 
                EleImg ret = new EleImg(parent, sprite, size, name);
                return ret;
            }
            
            public EleImg CreateImage(EleBaseRect parent, Sprite sprite, string name = "")
            { 
                EleImg ret = new EleImg(parent, sprite);
                return ret;
            }

            public ElePropGrid CreatePropertyGrid(EleBaseRect parent)
            { 
                ElePropGrid epg = new ElePropGrid(parent);
                return epg;
            }

            public EleInput CreateInput(EleBaseRect parent, bool multiline = false)
            { 
                EleInput inp = 
                    new EleInput(
                        parent, 
                        "", 
                        this.inputFont, 
                        this.inputFontColor, 
                        this.inputFontSize, 
                        multiline, 
                        this.inputSprite,
                        this.inputPadding,
                        new Vector2(-1.0f, -1.0f));

                return inp;
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