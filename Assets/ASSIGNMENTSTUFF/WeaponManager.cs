using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour
{
    //PREFABS
    public UnityEvent onWeaponChange; //UNITY EVENT =triggers when the weapon changes
    public GameObject normalability; //normal arrow prefab refference
    public GameObject doubleability; //double arrow prefab ref.
    public GameObject fastability; //fast arrow prefab ref.
    //BOWS
    public SpriteRenderer bowsprite; // sp component = displays bow sprite
    public Sprite emptybow; //sprite without arrow in bow
    public Sprite normalbow, doublebow, fastbow; //3 types of bows wit arrows in it

    private Coroutine powerupcoroutine; //COROUTIENE -ref. current pow.up corou
    private GameObject currentarrowprefab; //g/o currnt arrow prefeb

    public GameObject arrowprefab; //placeholder1
    public Sprite bowArt; //placeholder2
    //BUTTONS
    public GameObject normalabilitybutton; //blue
    public GameObject doubleabilitybutton; //purp
    public GameObject fastabilitybuton; //pink


    void Start()
    {
        bowsprite.sprite = emptybow; //no arrow in bow yet cuz nothing should be selected when game start
        EquipArrow(normalability, emptybow); //empty bow with normal ability equipppted
    }

    public void EquipArrow(GameObject arrowprefab, Sprite bowArt)
    {
        currentarrowprefab = arrowprefab; //set the current arrow prefab
        bowsprite.sprite = bowArt; //change bow sprite to match selected arrow suposively -seems to work when I play
        onWeaponChange.Invoke(); //unity event!!! trggered!!! when weapon changed!!!

        if (powerupcoroutine != null) //not null then;
        {
            StopCoroutine(powerupcoroutine); //stop corou
        }
        powerupcoroutine = StartCoroutine(poweruptimer()); //TRIAL AND ERROR = start new power-up timer coroutine? dont know if this works fully
        StartCoroutine(poweruptimer()); //another thing I tested- courou is starting and stopping though in console
        Debug.Log("coroustoped?");
    }

    IEnumerator poweruptimer()

    {
        Debug.Log("corou u there?"); //confirm coroutine started
        yield return new WaitForSeconds(5f); //waits for 5
        EquipArrow(normalability, normalbow); //returns back to normal arrow affter power up time ends-
        //though it seems to not be consistently 5 seconds when I try tbh-
    }

    public GameObject getcurrentarrow()
    {
        return currentarrowprefab; //curent eqquipted arrow's prefab
    }


    public void cancelpowerup()
    {
        if (powerupcoroutine != null) //powerupcorou used
        {
            StopCoroutine(powerupcoroutine); //Stop the current power-up timer
            EquipArrow(normalability, normalbow); // Revert back to normal arrow and bow
        }
    }
    public void pinkpowerbutton()
    {

        EquipArrow(fastability, fastbow); // equip - fast arrow and fast bow sprite when pink button pressed

    }
}
