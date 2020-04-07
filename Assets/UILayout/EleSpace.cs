using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{ 
    namespace UIL
    { 
        public class EleSpace : Ele
        { 
            public EleSpace(Ele parent, LFlag flags, Vector2 size, string name = "")
                : base(parent, flags, size, name)
            { }

            public EleSpace(Ele parent, LFlag flags)
                : base(parent, flags, new Vector2(-1.0f, -1.0f), "")
            { }

            public override bool CanHaveChildren()
            {
                return false;
            }
        }
    }
}