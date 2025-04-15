using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    //1 unity event
    //2 listeners
    //remove listeners
    //1 coroutiene

    //Task:
    //3 arrow buttons; when mouse clicked, change the bow sprite to that colour, and F key- will shoot that colour's ability. end state: once score is at 10=winner, resets score after 3 seconds.
    //I was over scoping ^^ this is more reasonable 

    // solution= sprtie buttons? 

    //Implementation log: Mouse pressed, not lining up with bow sprtie change when power-up clicked, 
    //when mouse pressed =not changing abilities
    //f shoot working = not specific power up 
    // spawning 10 at random working, prefabs are hard 
    //spawning ability SPRITES, shooting arrow PREFABS
    //keeping shooting arrows as prefabs


    public WeaponManager weaponmanagerscript;
    public Transform firePoint;
    public SpriteRenderer bowSpriterenderer;
    public SpriteRenderer abilitysprites;

    public Sprite normalbow;
    public Sprite doublebow;
    public Sprite fastbow;
    public Sprite bowsprite;

    public GameObject[] allpowerupsgo; //test OP2 go=g/o
    public Powerup[] allpowerups; //test OP1

    public Powerup selectedPowerup; //script

    public GameObject[] abilityPrefabs;
    //public int numberToSpawn = 10;
    public Vector2 spawnAreaMin = new Vector2(-5f, -3f);
    public Vector2 spawnAreaMax = new Vector2(5f, 3f);

    void Start()
    {
        //THIS WAS TO SPAWN 10 RANDOM ARROW POWER UPS IN THE BEGINNING- NOT DOING THIS ANYMORE AS IM FOCUSING ON DEBUGGING THE REQUIRED ELEMENTS FOR THIS PROJECT 
        ////allpowerups = new Powerup[numberToSpawn]; //swictched to g/o to try, now switching it back

        ////for (int i = 0; i < numberToSpawn; i++)
        //{
        //    GameObject prefabtospawn = abilityPrefabs[Random.Range(0, abilityPrefabs.Length)];

        //    Vector3 spawnPos = new Vector3(Random.Range(spawnAreaMin.x, spawnAreaMax.x),
        //    Random.Range(spawnAreaMin.y, spawnAreaMax.y), 0f);

        //    allpowerupsgo[i] = Instantiate(prefabtospawn, spawnPos, Quaternion.identity); ///TEST IT OUT =g/o version

            //int type = Random.Range(0, 3);
            //if (type == 0) toSpawn = Instantiate(normalability);
            //else if (type == 1) toSpawn = Instantiate(doubleability);
            //else toSpawn = Instantiate(fastability);

            //toSpawn.transform.localPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);

        //}
    }


    void Update()
    {
        //BOW
        //------------------------------------
        //float moveX = Input.GetAxisRaw("Horizontal"); //dont want bow like that
        float moveY = Input.GetAxisRaw("Vertical");

        transform.localPosition += new Vector3(0, moveY, 0f) * Time.deltaTime * 5f;
        //------------------------------------
        //MOUSE
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;

            //Vector3 closestPos = Vector3.zero;
            float minDistance = 10000;
            //int index = 0;
            int closestindex = -1;



            for (int i = 0; i < allpowerups.Length; i++)
            {
                //Vector3 puPos = allpowerups[i].transform.localPosition;
                // Vector3 bowPos = transform.localPosition;
                // Vector3 puPos = allpowerups[i].transform.localPosition;

                float distX = Mathf.Abs(mouseWorld.x - allpowerups[i].transform.localPosition.x);
                float distY = Mathf.Abs(mouseWorld.y - allpowerups[i].transform.localPosition.y);
                float dist = distX + distY;
                //Debug.Log("testing mouse");

                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestindex = i;
                }

            }

            if (closestindex != -1) //commented out because it was assigned in order? 
            {
                //  selectedPowerup = allpowerups[closestindex];
                Debug.Log("MOUSE: " + selectedPowerup.name); //mouse 
                selectedPowerup.CollectPowerUp(bowSpriterenderer, weaponmanagerscript, normalbow, doublebow, fastbow);

                Sprite selected = allpowerups[closestindex].powerupRenderer.sprite;

                if (selected == normalbow)
                {
                    weaponmanagerscript.EquipArrow(abilityPrefabs[0], normalbow); //blue is 0
                }
                else if (selected == doublebow)
                {
                    weaponmanagerscript.EquipArrow(abilityPrefabs[1], doublebow); //purp 1
                }
                else if (selected == fastbow)
                {
                    weaponmanagerscript.EquipArrow(abilityPrefabs[2], fastbow); // pink 2
                }
                allpowerups[closestindex].transform.localPosition = new Vector3(1000, 1000, 0);
            }
        }
        //-----------------------
        //FFFFFF
        // if (Input.GetKeyDown(KeyCode.F) //&& selectedPowerup != null ) && selectedPowerup.isActivated) //test
        // if (Input.GetKeyDown(KeyCode.F) && selectedPowerup.isActivated) //test
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject arrow = weaponmanagerscript.getcurrentarrow();
            if (arrow != null)
            {
                Debug.Log("F key pressed, firing arrow with selected power-up");
                //  Vector3 spawnPos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0); //test
                //  Instantiate(arrow, firePoint.position, Quaternion.identity); //test
                GameObject newArrow = Instantiate(arrow, firePoint.transform.position,Quaternion.identity);

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
                Destroy(newArrow, 5); //working

            }
        }


    }
    public void pinkarrow()
    {
        bowSpriterenderer.sprite = fastbow;
        Debug.Log("PINK WORKS");

    }

    public void purplearrow()
    {
        bowSpriterenderer.sprite = doublebow;
        weaponmanagerscript.EquipArrow(abilityPrefabs[1], doublebow);
        Debug.Log("PURPLE WORKS");

    }
    public void bluearrow()
    {
        bowSpriterenderer.sprite = normalbow;
        Debug.Log("BLUE WORKS");

    }
}
