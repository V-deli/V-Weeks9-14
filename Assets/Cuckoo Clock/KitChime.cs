using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public KitClock clockkit;

    private void Start()
    {
        clockkit.OnTheHour.AddListener(Chime);
    }
    public void Chime(int hour) //adding int other script
    {
        Debug.Log("Chiming !" + hour + "oclock !");
    }
    public void chimewithoutarguments()
    {
        Debug.Log("Chiming!");
    }
}
