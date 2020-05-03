using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleBoxSizer : Ele
        {
            Direction direction = Direction.Vert;
            Dictionary<Ele, float> proportions = new Dictionary<Ele, float>();

            public EleBoxSizer(Ele parent, Direction direction, LFlag flags, Vector2 size)
                : base(parent, flags, size, "")
            {
            }

            public EleBoxSizer(Ele parent, Direction direction, LFlag flags)
                : base(parent, flags)
            { 
            }

        }
    }
}