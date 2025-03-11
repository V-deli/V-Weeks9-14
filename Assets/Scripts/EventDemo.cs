using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //new
using UnityEngine.UI;

public class EventDemo : MonoBehaviour
{
    public Image bananaa; //old
    public RectTransform banana; //new

    public UnityEvent Timerhasfinished;//new
    public float timerLength = 2f;
    public float t;
    //new = event trigger
    void Start()
    {

    }


    void Update()
    {
        t += Time.deltaTime;
        if(t> timerLength)
        {
            t = 0;
            Timerhasfinished.Invoke(); //new
        }
    }
   // public void 

    public void Ijustpushedthebutton()
        {
        Debug.Log("Button Pushed");
}
    public void Iaslopushedthebutton()
    {
        Debug.Log("I also did");
    }
    public void MouseisNowInside()
    {
        Debug.Log("Mouse has entered this sprite");
        banana.localScale = Vector3.one * 1.2f;
    }
    public void MouseisNowOOutside()
    {
        Debug.Log("Mouse has left this sprite");
    }
}
