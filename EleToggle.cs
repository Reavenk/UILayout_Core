using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleToggle : Ele
        {
            public EleToggle(Ele parent, string text, Sprite plateSprite, Sprite toggleSprite, float iconWidth, float separation, PadRect togglePad, LFlag flags, Vector2 size, string name = "")
            { 
            }

            public EleToggle(Ele parent, string text, Sprite plateSprite, Sprite toggleSprite, float iconWidth, float separation, float pad, LFlag flags, Vector2 size, string name = "")
            { 
            }

            protected void _Create(Ele parent, string text, Sprite plateSprite, Sprite toggleSprite, float iconWidth, float separation, PadRect togglePad, LFlag flags, Vector2 size, string name)
            { 
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