using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSquare : MonoBehaviour
{
    public float t;

    public void Grow()
    {
        StartCoroutine(GetBigger());
    }

    IEnumerator GetBigger()
    {
        t = 0;
        //Debug.Log("Starting!");
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
            //Debug.Log("Time to yield!");
            yield return null;
        }
        //Debug.Log("THE END!");
    }
}
