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
    public Sprite normalbow, doublebow, fastbow;

    private Coroutine powerupcoroutine;
    private GameObject currentarrowprefab;



    void Start()
    {
        EquipArrow(normalability, normalbow);
    }

    public void EquipArrow(GameObject arrowprefab, Sprite bowArt)
    {
        currentarrowprefab = arrowprefab;
        bowsprite.sprite = bowArt;
        onWeaponChange.Invoke();

        if (powerupcoroutine != null)
        {
            StopCoroutine(powerupcoroutine);
        }
        powerupcoroutine = StartCoroutine(poweruptimer());
    }

    IEnumerator poweruptimer()
   
    {
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
