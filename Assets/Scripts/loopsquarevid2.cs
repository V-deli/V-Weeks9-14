using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopsquarevid2 : MonoBehaviour
{
    public float t;


    public void grow()
    {
        StartCoroutine(getbigger()); //calling getbigger but adding it in start corou.
    }
    IEnumerator getbigger()
    {
        t = 0;
        Debug.Log("starting");
        while (t < 1) //typically use while statement with coroutiene
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
            Debug.Log("Time to yield");
            yield return null; //ending statement for IEnumerator
                               
        }

        Debug.Log("The end");

        

        
    }
}
