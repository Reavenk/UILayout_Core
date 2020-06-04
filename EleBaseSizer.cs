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

            public void AddHorizontalSpace(float width, float proportion = 0.0f, LFlag flags = 0)
            {
                this.AddSpace(new Vector2(width, 0.0f), proportion, flags);
            }

            public void AddVerticalSpace(float height, float proportion = 0.0f, LFlag flags = 0)
            {
                this.AddSpace(new Vector2(0.0f, height), proportion, flags);
            }

            public void AddSpace(Vector2 space, float proportion = 0.0f, LFlag flags = 0)
            {
                this.Add(new EleSpace(space), proportion, flags);
            }

            public void AddSpace(float space, float proportion = 0.0f, LFlag flags = 0)
            {
                this.Add(new EleSpace(space), proportion, flags);
            }

            public EleBaseSizer(EleBaseRect rect, string name = "")
                : base(name)
            { 
                rect.SetSizer(this);
            }

            public EleBaseSizer(string name = "")
                : base(name)
            { }

            public EleBaseSizer(EleBaseSizer parent, float proportion, LFlag flags, string name = "")
                : base(name)
            { 
                parent.Add(this, proportion, flags);
            }

            public EleBaseSizer(){ }
        }
    }
}
