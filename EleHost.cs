using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace UIL
    {
        public class EleHost : EleBaseRect
        {
            RectTransform rt;

            public EleHost(RectTransform host, string name = "")
                : base(null, new Vector2(-1.0f, -1.0f), name)
            { 
                this.rt = host;
            }

            public override RectTransform RT => this.rt;
            
            public void LayoutInRT()
            { 
                Rect r = this.rt.rect;
                Dictionary<Ele, float> widths = new Dictionary<Ele, float>();
                Dictionary<Ele, Vector2> cached = new Dictionary<Ele, Vector2>();

                this.GetMinWidth(widths);
                this.GetMinSize(cached, widths, r.width);

                Vector2 ret = Vector2.zero;
                if (this.sizer != null)
                {
                    Vector2 szRet = 
                        this.sizer.Layout(
                            cached, 
                            widths, 
                            Vector2.zero, 
                            Vector2.zero, 
                            r.size);

                    ret = 
                        Vector2.Max(ret, szRet);
                }
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