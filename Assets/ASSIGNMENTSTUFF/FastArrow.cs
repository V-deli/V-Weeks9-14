using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastArrow : MonoBehaviour
{

    void Update()
    {
        transform.position += Vector3.right * 6f * Time.deltaTime;
    }
}
