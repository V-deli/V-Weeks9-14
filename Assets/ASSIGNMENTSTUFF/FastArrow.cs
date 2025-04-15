using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastArrow : MonoBehaviour
{
    private bool moveRight = false;

    void Update()
    {
        if (moveRight)
        {
            transform.localPosition += Vector3.right * 10f * Time.deltaTime; //only really changed the time (and colour)
        }
    }

    public void Activate(Vector3 newPos)
    {
        transform.localPosition = newPos;
        moveRight = true;
    }
}