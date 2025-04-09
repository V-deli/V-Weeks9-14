using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalArrow : MonoBehaviour
{
   
     void Update()
    {
        transform.position += transform.up * 3f * Time.deltaTime;
    }
}
