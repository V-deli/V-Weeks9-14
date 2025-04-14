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
    private Powerup selectedPowerup;

    public GameObject[] abilityPrefabs;
    public int numberToSpawn = 10;
    public Vector2 spawnAreaMin = new Vector2(-5f, -3f);
    public Vector2 spawnAreaMax = new Vector2(5f, 3f);

    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            GameObject prefabtospawn = abilityPrefabs[Random.Range(0, abilityPrefabs.Length)];

            Vector3 spawnPos = new Vector3(Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y), 0f);

            Instantiate(prefabtospawn, spawnPos, Quaternion.identity);

            //        int type = Random.Range(0, 3);
            //        if (type == 0) toSpawn = Instantiate(normalability);
            //        else if (type == 1) toSpawn = Instantiate(doubleability);
            //        else toSpawn = Instantiate(fastability);

            //        toSpawn.transform.localPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
            
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
            mouseWorld.z = 0f;

            //Vector3 closestPos = Vector3.zero;
            float minDistance = 9999f;
            int index = 0;
            int closestindex = -1;


            
            while (index < allpowerups.Length)
            {
                //Vector3 puPos = allpowerups[i].transform.localPosition;
                // Vector3 bowPos = transform.localPosition;
                // Vector3 puPos = allpowerups[i].transform.localPosition;

                float distX = Mathf.Abs(mouseWorld.x - allpowerups[index].transform.localPosition.x);
                float distY = Mathf.Abs(mouseWorld.y - allpowerups[index].transform.localPosition.y);
                float dist = distX * distX + distY;

                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestindex = index;
                }
                index++;
            }

            if (closestindex != -1)
            {
                selectedPowerup = allpowerups[closestindex];
                selectedPowerup.CollectPowerUp(bowSpriterenderer, weaponmanagerscript, normalbow, doublebow, fastbow);
                //    Sprite selected = allpowerups[closestIndex].powerupRenderer.sprite;

                //    if (selected == normalbow)
                //    {
                //        weaponmanagerscript.EquipArrow(normalability, normalbow);
                //    }
                //    else if (selected == doublebow)
                //    {
                //        weaponmanagerscript.EquipArrow(doubleability, doublebow);
                //    }
                //    else if (selected == fastbow)
                //    {
                //        weaponmanagerscript.EquipArrow(fastability, fastbow);
                //    }
                //    allpowerups[closestIndex].transform.localPosition = new Vector3(1000, 1000, 0);
                //}
            }
        

        if(Input.GetKeyDown(KeyCode.F) && selectedPowerup != null && selectedPowerup.isActivated)
        {
            GameObject arrow = weaponmanagerscript.getcurrentarrow();
            if (arrow != null)
            {
                    //Vector3 spawnPos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
                    //Instantiate(arrow, firePoint.position, Quaternion.identity);
                    GameObject newArrow = Instantiate(arrow);

                    if (newArrow.GetComponent<NormalArrow>() != null)
                    {
                        newArrow.GetComponent<NormalArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y, 0f));
                    }
                    else if (newArrow.GetComponent<FastArrow>() != null)
                    {
                        newArrow.GetComponent<FastArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y, 0f));
                    }
                    else if (newArrow.GetComponent<DoubleArrow>() != null)
                    {
                        newArrow.GetComponent<DoubleArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y, 0f));
                    }
                }
            }
        }

    }
}
