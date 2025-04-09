using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleArrow : MonoBehaviour
{
    public GameObject singlearrow;
   public Transform firePoint;
    
    public void Shoot()
    {
        Vector3 topoffset = new Vector3(0, 0.3f, 0); //top arrow
        Vector3 downoffset = new Vector3(0, -0.3f, 0); //bottom arrow

        GameObject arrow1 = Instantiate(singlearrow, firePoint.position + topoffset, Quaternion.identity);
        GameObject arrow2 = Instantiate(singlearrow, firePoint.position + downoffset, Quaternion.identity);

        

    }
}
