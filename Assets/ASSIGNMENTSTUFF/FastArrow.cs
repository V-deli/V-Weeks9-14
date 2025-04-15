using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastArrow : MonoBehaviour
{
    private bool moveRight = false; //tracks whether it moves in the right direction, cuz if not its wrong (another pun)

    void Update()
    {
        if (moveRight) //if its moving right then-
        {
            transform.localPosition += Vector3.right * 10f * Time.deltaTime; //move arrow to R rly fast 10 speed!!! -only really changed the time (and colour)
        }
    }

    public void Activate(Vector3 newPos) //arrow activated therefore-
    {
        transform.localPosition = newPos; //position set to given location
        moveRight = true; //is indeed moving right : )
    }
}