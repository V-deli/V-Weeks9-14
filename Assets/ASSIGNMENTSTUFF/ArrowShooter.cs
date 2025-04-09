using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    public Transform firePoint;
    public WeaponManager weaponmanagerscript;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject arrow = weaponmanagerscript.getcurrentarrow();
            if (arrow != null)
            {
                Instantiate(arrow, firePoint.position, Quaternion.identity);
            }
        }
    }
}
