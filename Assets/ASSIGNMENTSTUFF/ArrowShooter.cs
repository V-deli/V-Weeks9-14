using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    //1 unity event= event trigger
    //2 listeners
    //remove listeners
    //1 coroutiene

    //Task:
    //3 arrow buttons; when mouse clicked, change the bow sprite to that colour, and F key- will shoot that colour's ability. end state: once score is at 30=winner, resets score after _ seconds.
    //I was over scoping before ^^ this is more reasonable 

    // solution= sprtie buttons? =yes did this worked too!

    //Implementation log: Mouse pressed, not lining up with bow sprtie change when power-up clicked, 
    //when mouse pressed =not changing abilities
    //f shoot working = not specific power up 
    // spawning 10 at random working, prefabs are hard 
    //spawning ability SPRITES, shooting arrow PREFABS
    //gonna make it keep shooting arrows as prefabs


    public WeaponManager weaponmanagerscript; //ref. the weapon script to access it
    public Transform firePoint; //ref. the point the arrows will fire from 
    public SpriteRenderer bowSpriterenderer; //ref. SR bow
    public SpriteRenderer abilitysprites; //sprites of arrows (not bows)

    public Sprite normalbow; //normal bow sprite = blue arrow
    public Sprite doublebow; //double bow sprite =purple arrow
    public Sprite fastbow; //fast bow sprite = pink arrow
    
    //Before I was alternating between changing the powerup to gameobject and vice versa, only worked when I kept both
    public Powerup[] allpowerups; //test OP1 , power up script array = for all the power ups

    public Powerup selectedPowerup; //script , the power up thats selected in game

    public GameObject[] abilityPrefabs; //array of prefabs for different types of shooting arrows = the 3 of them
    

    void Start()
    {
        //I HAD CODE HERE THAT WAS TO SPAWN 10 RANDOM ARROW POWER UPS IN THE BEGINNING- NOT DOING THIS ANYMORE AS IM FOCUSING ON DEBUGGING THE REQUIRED ELEMENTS FOR THIS PROJECT 
        
        weaponmanagerscript.onWeaponChange.AddListener(updatedbowsprite); //added listener to weapon managers script event
        weaponmanagerscript.onWeaponChange.AddListener(logchange); //added listener to log changes in weapon
        StartCoroutine(removelistenerzafterdelay()); //  start a coroutine to remove the listeners after a delay
    }
        void updatedbowsprite() // ref. above in start
        {
            Debug.Log("Bow sprite updated!"); //to tell me it works when bow sprite is updated, though I never see this message
        }

        void logchange() //ref. above in start
        {
            Debug.Log("Arrow equipped!"); //also have never seen this message
        }

        IEnumerator removelistenerzafterdelay() //last one ref. above in start
        {
            yield return new WaitForSeconds(5f); //waits for 5 seconds
            weaponmanagerscript.onWeaponChange.RemoveListener(logchange); //after waiting remover listener
            Debug.Log("Removed listener: LogChange"); //logs the removal of listener
        }


    void Update()
    {
        //BOW
        //------------------------------------
        
        float moveY = Input.GetAxisRaw("Vertical"); 
        //moves my player bow sprite up and down only (intentional)
        transform.localPosition += new Vector3(0, moveY, 0f) * Time.deltaTime * 5f;

        //------------------------------------
        //MOUSE--- Keeping cuz I tried to comment it out cuz I have buttons now but it all went downhill without this clump of code
        if (Input.GetMouseButtonDown(0)) //before the buttons I had sprites to click on, this checks if the L mouse is pressed
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); //world position of the mouse/cursor thing
            mouseWorld.z = 0f; //dont need z

            float minDistance = 10000; //made this as a safety procaution
            int closestindex = -1; 
            //had this to update the closest sprite when theyd spawn before I changed that part
            //before: unity needed to know where the arrow powerups were spawned, needed to make sure the one that was clicked on was the arrow being used when f-key would be pressed =fire

            for (int i = 0; i < allpowerups.Length; i++) //for loop-s through powerups
            {
                float distX = Mathf.Abs(mouseWorld.x - allpowerups[i].transform.localPosition.x); //distance x axis
                float distY = Mathf.Abs(mouseWorld.y - allpowerups[i].transform.localPosition.y); //distance y axis
                float dist = distX + distY; //total distance
                

                if (dist < minDistance) //another safety thing I made: if this power up is closer than the previous one
                {
                    minDistance = dist; //then update the min dist
                    closestindex = i; //and the index of whats closest
                }

            }

            if (closestindex != -1) //commented out originally because i thought it was assigned in order on the inspector and that was why it was clicking in a predetermined order=BUT I managed to make it work by making 3 voids at the very bottom
            {
                selectedPowerup.CollectPowerUp(bowSpriterenderer, weaponmanagerscript, normalbow, doublebow, fastbow); //collect the power up
                Sprite selected = allpowerups[closestindex].powerupRenderer.sprite; //get the sprite of the selected powerup
                //BELOW: Im essentially linking the bow sprites to that of the arrow...
                //this makes the correct bow sprite activate, doing it further by the voids down below and recalling lines of code to make sure its good and gets done
                if (selected == normalbow) 
                {
                    weaponmanagerscript.EquipArrow(abilityPrefabs[0], normalbow); //normal bow = blue is 0
                }
                else if (selected == doublebow)
                {
                    weaponmanagerscript.EquipArrow(abilityPrefabs[1], doublebow); //double bow = purp 1
                }
                else if (selected == fastbow)
                {
                    weaponmanagerscript.EquipArrow(abilityPrefabs[2], fastbow); // fast bow = pink 2
                }
                allpowerups[closestindex].transform.localPosition = new Vector3(1000, 1000, 0); //move out of view
            }
        }
        //-----------------------
        //FFFFFF KEY PRESSED

        if (Input.GetKeyDown(KeyCode.F)) //so if a f key is pressed, arrows will shoot, other scripts ref this and the way they shoot change depending on the colour/ability/arrowtype
        {
            GameObject arrow = weaponmanagerscript.getcurrentarrow(); //get thecureent arrow prefab, the same type clicked on
            if (arrow != null) //if arrow not nul then: do the following
            {
                Debug.Log("F key pressed, firing arrow with selected power-up"); //making sure it works and this part does yipee
                GameObject newArrow = Instantiate(arrow, firePoint.transform.position,Quaternion.identity); //INSTANTIATES ARROWS HERE, NOT IN NORMAL AND FAST SCRIPT- at the fire point

                if (newArrow.GetComponent<NormalArrow>() != null)
                {
                    newArrow.GetComponent<NormalArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y, 0f)); //if normal, activate normal to shoot
                }
                else if (newArrow.GetComponent<FastArrow>() != null)
                {
                    newArrow.GetComponent<FastArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y, 0f)); //if fast arrow, activate fast to shoot
                }
                else if (newArrow.GetComponent<DoubleArrow>() != null)
                {
                    GameObject newArrow2 = Instantiate(arrow, firePoint.transform.position, Quaternion.identity); //instantiate another 2nd arrow for double arrow since the other 1 of the double arrow is already instantiated
                    newArrow.GetComponent<DoubleArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y +0.5f, 0f)); //got 2 lines for double arrows one on top, one on bottom
                    newArrow2.GetComponent<DoubleArrow>().Activate(new Vector3(firePoint.localPosition.x, transform.localPosition.y - 0.5f, 0f)); //this the bottom one=code the same except for -0.5
                    Destroy(newArrow2, 5); //working ---destroy specifally bottom double arrow g/0 after 5 seconds
                }
                Destroy(newArrow, 5); //working  ----this destory works for all the others outside the else if statement, after 5
            }
        }


    }
    //BEST DECISION
    public void pinkarrow()
    {
        bowSpriterenderer.sprite = fastbow; //sets sprite equal to fastbow sprite
        weaponmanagerscript.EquipArrow(abilityPrefabs[2], fastbow); //fast arrow prefab from weapon manager script
        Debug.Log("PURPLE WORKS"); //this helped and seems to work too

    }

    public void purplearrow()
    {
        bowSpriterenderer.sprite = doublebow; //SR.sprite = double type sprite
        weaponmanagerscript.EquipArrow(abilityPrefabs[1], doublebow); //gettingp prefab from script
        Debug.Log("PINK WORKS"); //works

    }
    public void bluearrow()
    {
        bowSpriterenderer.sprite = normalbow; //SR.sprite = normal type sprite
        weaponmanagerscript.EquipArrow(abilityPrefabs[0], normalbow); //gettingp arrow prefab from script
        Debug.Log("BLUE WORKS"); //works

    }
}
