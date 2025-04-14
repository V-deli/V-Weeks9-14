using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    public WeaponManager weaponmanagerscript;
    public Transform firePoint;
    public SpriteRenderer bowSpriterenderer;

    public Sprite normalsprite;
    public Sprite doublearowsprite;
    public Sprite fastarrowsprite;

    public Powerup[] allpowerups;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.localPosition += new Vector3(moveX, moveY, 0f) * Time.deltaTime * 5f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Powerup powerup in allpowerups) // in vv
            {
                Vector3 bowPos = transform.localPosition;
                Vector3 puPos = powerup.transform.localPosition;

                float diffX = Mathf.Abs(bowPos.x - puPos.x);
                float diffY = Mathf.Abs(bowPos.y - puPos.y);

                if (diffX < 1.0f && diffY < 1.0f)
                {
                    powerup.CollectPowerUp(bowSpriterenderer, weaponmanagerscript, normalsprite, doublearowsprite, fastarrowsprite);
                    break; //suggested by visual studio? , know I can use foreach but I dont recall learning this, ill check the videos
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
