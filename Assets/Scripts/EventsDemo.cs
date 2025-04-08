using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventsDemo : MonoBehaviour
{

    public RectTransform banana;

    public UnityEvent TimerHasFinished;
    public float timerLength = 2;
    public float t;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t > timerLength)
        {
            t = 0;
            TimerHasFinished.Invoke();
        }
    }

    public void IJustPushedTheButton()
    {
        Debug.Log("I just pushed the button!");
    }

    public void IAlsoPushedTheButton()
    {
        Debug.Log("I also pushed the button!");
    } 

    public void MouseIsNowInside()
    {
        banana.localScale = Vector3.one * 1.2f;

        Debug.Log("Mouse has entered the sprite");
    }

    public void MouseIsNowOutside()
    {
        banana.localScale = Vector3.one;

        Debug.Log("Mouse has left the sprite");
    }
}
