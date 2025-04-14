using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    public WeaponManager weaponmanagerscript;
    public Transform firePoint;
    public SpriteRenderer bowSpriterenderer;

    public Sprite normalsprite;
    public Sprite doublearowsprite;
    public Sprite fastarrowsprite;

    private string currentArrowType = "Normal";

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.localPosition += new Vector3(moveX, moveY, 0f) * Time.deltaTime * 5f;


    }
}
