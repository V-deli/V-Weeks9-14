using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpgrowerwk10vid1 : MonoBehaviour
{
   public AnimationCurve curve;
    public float minSize = 0;
    public float maxSize = 1;
    public float t;
    public bool startGrowing;

    private void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    startgrowing();
        //}

        if (startGrowing)
        {
            Grow();
        }
        //asynchronous code
    }
    public  void startgrowing()
    {
        startGrowing = true;
        t = 0;
    }

    private void Grow()
    {
        //t = Time.deltaTime;
        // Vector3 start = new Vector3(minSize, minSize, minSize);
        if (t < 1)
        {
            t = Time.deltaTime;
        }
        else
        {
            startGrowing = false;
        }

        transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
       // transform.localScale = Vector3.Lerp(Vector3.one * minSize, Vector3.one * maxSize, curve.Evaluate(t));
    }
}
