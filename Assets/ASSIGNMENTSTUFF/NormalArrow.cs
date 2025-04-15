using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalArrow : MonoBehaviour
{
    private bool moveRight = false; //to make sure the arrow moves in the *right* direction!! HAHA PUN INTENDED
    //initially set equal to false
    void Update()
    {
        if (moveRight) //if normal arow is moving to the right...
        {
            transform.localPosition += Vector3.right * 3f * Time.deltaTime; //note for me= just moves 2 r
            //move  arrow to .right at 3 speed
        }
    }

    public void Activate(Vector3 newPos) //this called whrn arrow is fired=f key
    {
        transform.localPosition = newPos; //starting pos of arrow
        moveRight = true; //now it is moving to the right- as it should
    }
}
    
