using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PxPre.UIL;

public class Test_SingleTextWrapped : Test
{
    public override string testName 
    {
        get 
        {
            return "Simple Single Text Wrapped";
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
        factory.CreateText(parent, "A test string of text.", true, 0);
    }
}
