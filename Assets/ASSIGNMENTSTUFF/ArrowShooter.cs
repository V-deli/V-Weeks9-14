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
    public GameObject normalability; //= pick ups
    public GameObject doubleability;
    public GameObject fastability;

     void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject toSpawn = null;
            int type = Random.Range(0, 3);
            if (type == 0) toSpawn = Instantiate(normalability);
            else if (type == 1) toSpawn = Instantiate(doubleability);
            else toSpawn = Instantiate(fastability);

            toSpawn.transform.localPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
        }
    }


    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.localPosition += new Vector3(moveX, moveY, 0f) * Time.deltaTime * 5f;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 closestPos = Vector3.zero;
            float minDistance = 9999f;
            int closestIndex = -1;

            int i = 0;
            while (i < allpowerups.Length)
            {
                Vector3 puPos = allpowerups[i].transform.localPosition;
                // Vector3 bowPos = transform.localPosition;
                // Vector3 puPos = allpowerups[i].transform.localPosition;

                float distX = mouseWorld.x - puPos.x;
                float distY = mouseWorld.y - puPos.y;
                float dist = distX * distX + distY * distY;

                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestPos = puPos;
                    closestIndex = i;
                }
                i++;
            }

            if (closestIndex != -1)
            {
                Sprite selected = allpowerups[closestIndex].powerupRenderer.sprite;

                if (selected == normalbow)
                {
                    weaponmanagerscript.EquipArrow(normalability, normalbow);
                }
                else if (selected == doublebow)
                {
                    weaponmanagerscript.EquipArrow(doubleability, doublebow);
                }
                else if (selected == fastbow)
                {
                    weaponmanagerscript.EquipArrow(fastability, fastbow);
                }
                allpowerups[closestIndex].transform.localPosition = new Vector3(1000, 1000, 0);
            }
        }
        

        if(Input.GetKeyDown(KeyCode.F))
        {
            GameObject arrow = weaponmanagerscript.getcurrentarrow();
            if (arrow != null)
            {
                Vector3 spawnPos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
                Instantiate(arrow, firePoint.position, Quaternion.identity);
            }
        }

    }
}
