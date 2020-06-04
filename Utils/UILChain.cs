using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UILChain
{
    public static PxPre.UIL.EleImg Chn_SetImgType(this PxPre.UIL.EleImg img, UnityEngine.UI.Image.Type type)
    { 
        img.Img.type = type;
        return img;
    }

    public static PxPre.UIL.EleImg Chn_SetImgSliced(this PxPre.UIL.EleImg img)
    { 
        return img.Chn_SetImgType(UnityEngine.UI.Image.Type.Sliced);
    }

    public static PxPre.UIL.EleBoxSizer Chn_Border( this PxPre.UIL.EleBoxSizer szr, float all)
    { 
        szr.border = new PxPre.UIL.PadRect(all);
        return szr;
    }

    public static PxPre.UIL.EleBoxSizer Chn_Border( this PxPre.UIL.EleBoxSizer szr, PxPre.UIL.PadRect pr)
    {
        szr.border = pr;
        return szr;
    }

    public static PxPre.UIL.EleText Chn_TextAlignment(this PxPre.UIL.EleText txt, TextAnchor anchor)
    { 
        txt.text.alignment = anchor;
        return txt;
    }
}
