using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PxPre.UIL;

public class TestManager : MonoBehaviour
{
    public UnityEngine.UI.Button prevButton;
    public UnityEngine.UI.Button nextButton;
    public UnityEngine.UI.Text description;
    public RectTransform hostRect;
    public Factory factory;
    EleHost host = null;

    int testIndex;
    List<Test> tests = new List<Test>();

    private void Awake()
    {
        // Add tests here.
        this.tests.Add(new Test_SingleImage());
        this.tests.Add(new Test_SingleHeader());
        this.tests.Add(new Test_SingleTextWrapped());
        this.tests.Add(new Test_SingleButton());
        this.tests.Add(new Test_SingleHorizontalRule());
    }

    private void Start()
    {
        if (this.tests.Count == 0)
        { 
            this.DisableAllTests();
        }
        else
        { 
            this.GoToTestIndex(0);
        }
    }

    void ClearCurrentLayout()
    { 
        foreach(Transform rt in hostRect)
            GameObject.Destroy(rt.gameObject);

        this.host = null;
    }

    void GoToTestIndex(int idx)
    { 
        if(this.tests.Count == 0)
            return;

        this.testIndex = idx;

        this.prevButton.enabled = (this.testIndex != 0);
        this.nextButton.enabled = (this.testIndex != this.tests.Count - 1);

        Test t = this.tests[this.testIndex];
        this.description.text = t.testName;

        this.ClearCurrentLayout();
        this.host = new EleHost(this.hostRect, "");
        this.host.PrepareTopLeftUse();
        t.DoRunTest(this.host, this.factory);
        this.host.LayoutInRT();
    }

    void DisableAllTests()
    {
        this.prevButton.enabled     = false;
        this.nextButton.enabled     = false;
        this.testIndex              = -1;
        this.description.text       = "No valid tests.";
    }

    public void OnButtonNextTest()
    { 
        if(this.tests.Count == 0)
            return;

        if(this.testIndex >= this.tests.Count - 1)
            return;

        this.GoToTestIndex(this.testIndex + 1);
    }

    public void OnButtonPrevTest()
    { 
        if(this.tests.Count == 0)
            return;

        if(this.testIndex <= 0)
            return;

        this.GoToTestIndex(this.testIndex - 1);
    }
    

}
