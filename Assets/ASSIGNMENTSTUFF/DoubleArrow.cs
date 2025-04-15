using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleArrow : MonoBehaviour
{
   //public GameObject arrowPrefab;
    private bool fired = false;
    //private Vector3 spawnPos;
   // public WeaponManager weaponManager;

    public void Activate(Vector3 newPos)
    {
        transform.localPosition = newPos;
        fired = true;
    }

     void Update()
    {
        if (fired)
        {
            transform.localPosition += Vector3.right * 3f * Time.deltaTime; //just moves 2 r
            //transform.localPosition += Vector3.right + Vector3.down * 3f * Time.deltaTime; //just moves 2 r

            //Instantiate(arrowPrefab, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity); //one above
            //Instantiate(arrowPrefab, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity); //one below
            //fired = false;
            //Destroy(gameObject);
        }
    }
}
