using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public UnityEvent onWeaponChange;
    public GameObject normalarrowprefab;
    public GameObject doublearrowprefab;
    public GameObject fastarrowprefab;
    public SpriteRenderer bowsprite;
    public Sprite normalarrow, doublearrow, fastarrow;

    private Coroutine powerupcoroutine;
    private GameObject currentarrowprefab;



    void Start()
    {
        EquipArrow(normalarrowprefab, normalarrow);
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
        powerupcoroutine = StartCoroutine(poweruptimer);
    }

    IEnumerator poweruptimer()
   
    {
        yield return new WaitForSeconds(5f);
        EquipArrow(normalarrowprefab, normalarrow);
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
            EquipArrow(normalarrowprefab, normalarrow);
        }
    }
}
