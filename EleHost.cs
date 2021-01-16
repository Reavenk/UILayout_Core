// <copyright file="EleHost.cs" company="Pixel Precision LLC">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>William Leu</author>
// <date>09/25/2020</date>
// <summary></summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre.UIL
{
    public class EleHost : EleBaseRect
    {
        RectTransform rt;

        public EleHost(RectTransform host, bool autolayout, bool clearPrev = true, string name = "")
            : base(null, new Vector2(-1.0f, -1.0f), name)
        { 
            this.rt = host;

            if(clearPrev == true)
            {
                HostLayoutOnSizeChange [] hls = 
                    host.gameObject.GetComponents<HostLayoutOnSizeChange>();

                foreach(HostLayoutOnSizeChange hl in hls)
                    GameObject.Destroy(hl);
            }

            if(autolayout == true)
                HostLayoutOnSizeChange.AttachHost(host.gameObject, this);
        }

        public override RectTransform RT => this.rt;
            
        public Vector2 LayoutInRT(bool collapsable = true)
        { 
            Rect r = this.rt.rect;
            Dictionary<Ele, float> widths = new Dictionary<Ele, float>();
            Dictionary<Ele, Vector2> cached = new Dictionary<Ele, Vector2>();

            this.GetMinWidth(widths);
            this.GetMinSize(cached, widths, r.width, collapsable);

            Vector2 ret = Vector2.zero;
            if (this.sizer != null)
            {
                Vector2 szRet = 
                    this.sizer.Layout(
                        cached, 
                        widths, 
                        Vector2.zero, 
                        Vector2.zero, 
                        r.size,
                        collapsable);

                ret = 
                    Vector2.Max(ret, szRet);
            }

            return ret;
        }

        public Vector2 LayoutInRTSmartFit()
        { 
            const float buffer = 0.1f;
            Rect r = this.rt.rect;

            Vector2 rsz = LayoutInRT(false);
            if(rsz.y > r.height + buffer)
                rsz = LayoutInRT(true);

            return rsz;
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