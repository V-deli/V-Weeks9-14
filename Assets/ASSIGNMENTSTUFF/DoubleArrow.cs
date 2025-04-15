using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleArrow : MonoBehaviour
{
    private bool fired = false; //to track if this arrow type fired or not

    public void Activate(Vector3 newPos) //made to activate arrow
    {
        transform.localPosition = newPos; //set arrows pos to given pos
        fired = true; //now is moving, marks it moving, so it moves
    }

     void Update()
    {
        if (fired) // in update, I check if fired
        {
            transform.localPosition += Vector3.right * 3f * Time.deltaTime; //arrows will meve to right at same time , 3 speed
        }
    }
}
