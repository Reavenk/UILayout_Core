using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PxPre.UIL;

public abstract class Test
{
    public abstract string testName {get;}
    public abstract string description {get; }
    public abstract void DoRunTest(Ele parent, Factory factory);
}
