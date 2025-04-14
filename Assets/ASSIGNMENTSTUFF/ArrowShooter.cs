using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    public WeaponManager weaponmanagerscript;
    public Transform firePoint;
    public SpriteRenderer bowSpriterenderer;

    public Sprite normalbow;
    public Sprite doublebow;
    public Sprite fastbow;

    public Powerup[] allpowerups;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.localPosition += new Vector3(moveX, moveY, 0f) * Time.deltaTime * 5f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int i = 0;
            while (i < allpowerups.Length) 
            {
                Vector3 bowPos = transform.localPosition;
                Vector3 puPos = allpowerups[i].transform.localPosition;

                float diffX = Mathf.Abs(bowPos.x - puPos.x);
                float diffY = Mathf.Abs(bowPos.y - puPos.y);

                if (diffX < 1.0f && diffY < 1.0f)
                {
                    allpowerups[i].CollectPowerUp(bowSpriterenderer, weaponmanagerscript, normalbow, doublebow, fastbow);
                    i = allpowerups.Length;
                }
                else
                {
                    i++;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameObject arrow = weaponmanagerscript.getcurrentarrow();
            if (arrow != null)
            {
                Instantiate(arrow, firePoint.position, Quaternion.identity);
            }
        }

    }
}
