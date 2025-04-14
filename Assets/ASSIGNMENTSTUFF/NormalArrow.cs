using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalArrow : MonoBehaviour
{
   
     void Update()
    {
        transform.localPosition += Vector3.right * 3f * Time.deltaTime; //whoops
    }
}
