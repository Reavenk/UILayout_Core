using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public abstract class EleBaseSizer : Ele
        {
            bool active = true;

            public override bool Active { get { return this.active; } }

            public abstract void Add(Ele child, float proportion, LFlag flags);

            public EleBaseSizer(EleBaseRect rect)
            { 
                rect.SetSizer(this);
            }

            public EleBaseSizer(EleBaseSizer parent, float proportion, LFlag flags)
            { 
                parent.Add(this, proportion, flags);
            }

            public EleBaseSizer(){ }
        }
    }
}
