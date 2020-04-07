using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleInput : Ele
        { 
            UnityEngine.UI.InputField input = null;
            UnityEngine.UI.Text text = null;
            UnityEngine.UI.Text placeholder = null;

            public EleInput(Ele parent, string text, Font font, Color fontColor, int pointSize, bool multiline, Sprite plate, PadRect padding, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
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
                    flags, 
                    size, 
                    name);
            }

            public EleInput(Ele parent, string text, Font font, Color fontColor, int pointSize, bool multiline, Sprite plate, float padding, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
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
                    flags, 
                    size, 
                    name);
            }

            protected void _Create(Ele parent, string text, Font font, Color fontColor, int pointSize, bool multiline, Sprite plate, PadRect padding, LFlag flags, Vector2 size, string name)
            { 
                this.padding = padding;

                GameObject go = new GameObject("Input_" + name);
                go.transform.SetParent(parent.GetContentRect());



                GameObject goText = new GameObject("InputText_" + name);
                goText.transform.SetParent(go.transform);

                GameObject goPlaceholder = new GameObject("InputPlaceholder_" + name);
                goPlaceholder.transform.SetParent(go.transform);

            }

            public override bool CanHaveChildren()
            {
                return false;
            }

            protected override Vector2 ImplCalcMinSize(Dictionary<Ele, Vector2> cache, float width)
            {
            }

            public override void Layout(Dictionary<Ele, Vector2> cached, Vector2 rectOffset, Vector2 offset, Vector2 size)
            {
                base.Layout(cached, rectOffset, offset, size);
            }
        }
    }
}