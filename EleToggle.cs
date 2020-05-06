using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleToggle : EleBaseRect
        {
            UnityEngine.UI.Toggle toggle;
            RectTransform rt;

            public override RectTransform RT => this.rt;

            public EleToggle(EleBaseRect parent, string text, Sprite plateSprite, Sprite toggleSprite, float iconWidth, float separation, PadRect togglePad, LFlag flags, Vector2 size, string name = "")
                : base(parent, size, name)
            { 
            }

            public EleToggle(EleBaseRect parent, string text, Sprite plateSprite, Sprite toggleSprite, float iconWidth, float separation, float pad, LFlag flags, Vector2 size, string name = "")
                : base(parent, size, name)
            { 
            }

            protected void _Create(Ele parent, string text, Sprite plateSprite, Sprite toggleSprite, float iconWidth, float separation, PadRect togglePad, LFlag flags, Vector2 size, string name)
            { 
            }

            protected override Vector2 ImplCalcMinSize(
                Dictionary<Ele, Vector2> cache, 
                Dictionary<Ele, float> widths, 
                float width)
            {
                return Vector2.zero;
            }

            public override Vector2 Layout(
                Dictionary<Ele, Vector2> cached, 
                Dictionary<Ele, float> widths, 
                Vector2 rectOffset, 
                Vector2 offset, 
                Vector2 size)
            {
                return base.Layout(cached, widths, rectOffset, offset, size);
            }
        }
    }
}