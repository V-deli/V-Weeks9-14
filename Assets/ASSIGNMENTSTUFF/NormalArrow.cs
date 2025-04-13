using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalArrow : MonoBehaviour
{
   
     void Update()
    {
        transform.position += Vector3.up * 3f * Time.deltaTime;
    }
}
