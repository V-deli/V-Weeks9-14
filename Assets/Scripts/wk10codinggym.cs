using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wk10codinggym : MonoBehaviour
{
//Write a coroutine that makes a sprite grow using an AnimationCurve
public AnimationCurve battybuggie;
public Vector3 thesize;
public float time;
    Coroutine sizeChange;



    void Start()
    {
        
    }

    
    void Update()
    {
        time += Time.deltaTime;
        if (time >3)
        {
            time = 0;
        }
        battybuggie.Evaluate(time);
        transform.localScale = Vector2.one * battybuggie.Evaluate(time);
    }
}
