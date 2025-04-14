using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerup : MonoBehaviour
{
    public UnityEvent onPowerupcollected = new UnityEvent();
    public SpriteRenderer powerupRenderer;

    public void CollectPowerUp // v (cond) v
        (SpriteRenderer bowRenderer, WeaponManager weaponmanagerscript, Sprite normalsprite, Sprite doublearrowsprite, Sprite fastarrowsprite)
    {
        Sprite powerSprite = powerupRenderer.sprite;

        if (powerSprite == normalsprite)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.normalarrowprefab, normalsprite);
        }
        else if (powerSprite == doublearrowsprite)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.doublearrowprefab, doublearrowsprite);
        }
        else if (powerSprite == fastarrowsprite)
        {
            weaponmanagerscript.EquipArrow(weaponmanagerscript.fastarrowprefab, fastarrowsprite);
        }


        onPowerupcollected.Invoke();
        gameObject.SetActive(false);
    }

    

}
