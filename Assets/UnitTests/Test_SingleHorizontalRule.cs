using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PxPre.UIL;

public class Test_SingleHorizontalRule : Test
{
    public override string testName {
        get {
            return "Simple Horizontal Rule";
        }
    }

    public override string description {
        get {
            return "";
        }
    }

    public override void DoRunTest(Ele parent, Factory factory)
    { 
        factory.CreateHorizontalSeparator(parent);
    }
}
