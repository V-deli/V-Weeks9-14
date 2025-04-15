using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalArrow : MonoBehaviour
{
    private bool moveRight = false;

    void Update()
    {
        if (moveRight)
        {
            transform.localPosition += Vector3.right * 3f * Time.deltaTime; //just moves 2 r
        }
    }

    public void Activate(Vector3 newPos)
    {
        transform.localPosition = newPos;
        moveRight = true;
    }
}
    
