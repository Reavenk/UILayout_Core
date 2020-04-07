using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PxPre.UIL;

public class Test_SingleImage : Test
{
    public override string testName 
    {
        get 
        {
            return "Simple Single Image";
        }
    }

    public override string description 
    {
        get 
        {
            return "";
        }
    }

    public override void DoRunTest(Ele parent, Factory factory)
    { 
        Sprite sprite = Resources.Load<Sprite>("Box-128");
        factory.CreateImage(parent, sprite, 0);
    }
}