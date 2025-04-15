using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public UnityEvent onWeaponChange;
    public GameObject normalability; //= pick ups
    public GameObject doubleability;
    public GameObject fastability;
    public SpriteRenderer bowsprite;
    public Sprite emptybow;
    public Sprite normalbow, doublebow, fastbow;

    private Coroutine powerupcoroutine; //COROUTIENE
    private GameObject currentarrowprefab;

    public GameObject arrowprefab;
    public Sprite bowArt;

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
        onWeaponChange.Invoke();

        if (powerupcoroutine != null)
        {
            StopCoroutine(powerupcoroutine); //stop corou
        }
        StartCoroutine(poweruptimer());
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
}
