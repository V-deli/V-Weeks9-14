using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditisquarevid2 : MonoBehaviour
{
    public float t;

    public void grow()
    {
        if (t < 1)
        {
            t += Time.deltaTime;
            //yield return null;
            transform.localScale = Vector3.one * t;
        }
      
    }
}
