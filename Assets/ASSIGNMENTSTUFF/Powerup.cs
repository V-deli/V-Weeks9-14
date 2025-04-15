using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Powerup : MonoBehaviour
{
    public UnityEvent onPowerupcollected = new UnityEvent(); //UNITY EVENT= event triggered when the powerup is collected
    public SpriteRenderer powerupRenderer; //the sprite renderer for the p-up object
    public bool isActivated = false; //  check if p-up has already been collected
    public WeaponManager weaponManager; //script ref.

     void Start()
    {
        powerupRenderer = GetComponent<SpriteRenderer>(); //store the SR comp attached to g/o
    }

    public void CollectPowerUp // v (cond) v //function=power up coll= apply effects
    (SpriteRenderer bowRenderer, WeaponManager weaponmanagerscript, Sprite normalbow, Sprite doublebow, Sprite fastbow)
    {
        weaponManager = weaponmanagerscript; //assign script ref.
        onPowerupcollected.Invoke(); //triggers unity event- tells listeners p-up collected
        Sprite powerSprite = powerupRenderer.sprite; // store the sprite of the collected p-up

        if (powerSprite == normalbow)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.normalability, normalbow); //equip normal arrow
        }
        else if (powerSprite == doublebow)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.doubleability, doublebow); //equip double arrow
        }
        else if (powerSprite == fastbow)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.fastability, fastbow); //equip fast arrow
        }

        isActivated = true; //true= power up collected therefore activated.

    }
    //new add listener reference other void= thought I had
    



}
