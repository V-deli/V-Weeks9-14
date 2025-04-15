using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerup : MonoBehaviour
{
    public UnityEvent onPowerupcollected = new UnityEvent();
    public SpriteRenderer powerupRenderer;
    public bool isActivated = false;
    public ArrowShooter shooter; //script
    public WeaponManager weaponManager;

     void Start()
    {
        powerupRenderer = GetComponent<SpriteRenderer>();
    }

    public void CollectPowerUp // v (cond) v
    (SpriteRenderer bowRenderer, WeaponManager weaponmanagerscript, Sprite normalbow, Sprite doublebow, Sprite fastbow)
    {
        weaponManager = weaponmanagerscript;
        onPowerupcollected.Invoke();
        Sprite powerSprite = powerupRenderer.sprite;

        if (powerSprite == normalbow)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.normalability, normalbow);
        }
        else if (powerSprite == doublebow)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.doubleability, doublebow);
        }
        else if (powerSprite == fastbow)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.fastability, fastbow);
        }

        isActivated = true;

        //    gameObject.SetActive(false);
    }
    public void correctpowerup () //new add listener reference other void
    {
        //onPowerupcollected.AddListener(weaponManager.EquipArrow());
    }



}
