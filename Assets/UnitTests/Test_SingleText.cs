using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PxPre.UIL;

public class Test_SingleTest : Test
{
    public override string testName {
        get {
            return "Simple Single Text";
        }
    }

    public override string description {
        get {
            return "";
        }
    }

    public override void DoRunTest(Ele parent, Factory factory)
    { 
        factory.CreateText(parent, "A test string", true, 0);
    }
}
