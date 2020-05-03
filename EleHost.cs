using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleHost : Ele
        {
            RectTransform rt;

            public EleHost(RectTransform host, string name = "")
                : base(null, 0, new Vector2(-1.0f, -1.0f), name)
            { 
                this.rt = host;
            }

            public override RectTransform GetRT()
            {
                return this.rt;
            }

            public void LayoutInRT()
            { 
                Rect r = this.rt.rect;
                Dictionary<Ele, Vector2> cache = new Dictionary<Ele, Vector2>();

                this.CalcMinSize(cache, r.width);
                this.Layout(cache, Vector2.zero, Vector2.zero, r.size);
            }

            public void PrepareTopLeftUse()
            { 
                //this.rt.anchorMin = new Vector2(0.0f, 1.0f);
                //this.rt.anchorMax = new Vector2(0.0f, 1.0f);
                this.rt.pivot = new Vector2(0.0f, 1.0f);
                //this.rt.offsetMin = Vector2.zero;
                //this.rt.offsetMax = Vector2.zero;
            }
        }
    }
}