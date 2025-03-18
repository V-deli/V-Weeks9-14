using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;
    public Transform hourhand; //Transform
    public Transform minutehand;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour; //Unity Event
    Coroutine clockIsrunning; //new = coroutine
    IEnumerator doOnehr;

    void Start() //putting it in start, not update cuz we dont want it updating every frame
    {
        clockIsrunning=  StartCoroutine(MoveTheclock()); //calling the ieumeraor in an inemerator
    }

    private IEnumerator MoveTheclock()
    {
        while (true) //new
        {
            doOnehr = MoveTheclockhand1hr();
            yield return StartCoroutine(doOnehr);
        }
    }

    //    t += Time.deltaTime;

    //    if (t > timeAnHourTakes)
    //    {
    //        t = 0;
    //        OnTheHour.Invoke(); //Invoke

    //        hour++;
    //        if (hour == 12)
    //        {
    //            hour = 0;
    //        }
    //    }
    //}
    private IEnumerator MoveTheclockhand1hr() //Ienuumerator
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minutehand.Rotate(0, 0, -(360/timeAnHourTakes)*Time.deltaTime);
            hourhand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null; //yield
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }

        OnTheHour.Invoke (hour);
    }
    public void StopTheClock()
    {
        if (clockIsrunning != null)
        {
            StopCoroutine(clockIsrunning);

        }
        if (doOnehr != null)
        {
            StopCoroutine(doOnehr);
        }
        

    }
}
