using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public UnityEvent onWeaponChange; //UNITY EVENT
    public GameObject normalability;
    public GameObject doubleability;
    public GameObject fastability;
    public SpriteRenderer bowsprite;
    public Sprite emptybow;
    public Sprite normalbow, doublebow, fastbow;

    private Coroutine powerupcoroutine; //COROUTIENE
    private GameObject currentarrowprefab;

    public GameObject arrowprefab;
    public Sprite bowArt;

    public GameObject normalabilitybutton; //blue
    public GameObject doubleabilitybutton; //purp
    public GameObject fastabilitybuton; //pink


    void Start()
    {
        bowsprite.sprite = emptybow;
        EquipArrow(normalability, emptybow);
        //currentarrowprefab = null;
    }

    public void EquipArrow(GameObject arrowprefab, Sprite bowArt)
    {
        currentarrowprefab = arrowprefab;
        bowsprite.sprite = bowArt;
        onWeaponChange.Invoke(); //unity event

        if (powerupcoroutine != null)
        {
            StopCoroutine(powerupcoroutine); //stop corou
        }
        powerupcoroutine = StartCoroutine(poweruptimer()); //TRIAL AND ERROR
        StartCoroutine(poweruptimer());
        Debug.Log("coroustoped?");
    }

    IEnumerator poweruptimer()

    {
        Debug.Log("corou u there?");
        yield return new WaitForSeconds(5f);
        EquipArrow(normalability, normalbow);
    }

    public GameObject getcurrentarrow()
    {
        return currentarrowprefab;
    }


    public void cancelpowerup()
    {
        if (powerupcoroutine != null)
        {
            StopCoroutine(powerupcoroutine);
            EquipArrow(normalability, normalbow);
        }
    }
    public void pinkpowerbutton()
    {

        EquipArrow(fastability, fastbow);

    }
}
