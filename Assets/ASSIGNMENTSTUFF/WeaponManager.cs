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
        
    }

    
    void Update()
    {
        
    }
}
