using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerup : MonoBehaviour
{
    public GameObject arrowSpawnpoint;
    public GameObject normalArrowPrefab;
    public GameObject doubleArrowPrefab;
    public GameObject fastArrowPrefab;

    public UnityEvent onPowerupcollected = new UnityEvent();

    public SpriteRenderer bowRenderer;
    public Sprite normalsprite;
    public Sprite doublearrowsprite;
    public Sprite fastarrowsprite;

    private Coroutine powerUpCorou;
    private string currentArrowtype = "Normal";


    
    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.Return))
        {
            FireArrow();
        }
    }

    void FireArrow()
{
        if (currentArrowtype == "Normal")
        {
            Instantiate(normalArrowPrefab, arrowSpawnpoint.transform.position, Quaternion.identity);
        }
        else if (currentArrowtype == "Double")
        {
            Instantiate(doubleArrowPrefab, arrowSpawnpoint.transform.position, Quaternion.identity);
        }
        else if(currentArrowtype == "Fast")
        {
            Instantiate(fastArrowPrefab, arrowSpawnpoint.transform.position, Quaternion.identity);
        }
}

    public void CollectPowerUp(string type)
    {
        if (powerUpCorou != null)
        {
            StopCoroutine(powerUpCorou);
        }
        powerUpCorou = StartCoroutine(PowerUpTimer(type));
        onPowerupcollected.Invoke();
    }

    IEnumerator PowerUpTimer(string type)
    {
        currentArrowtype = type;
        UpdateBowSprite();
        yield return new WaitForSeconds(5f);
        currentArrowtype = "Normal";
        UpdateBowSprite();
    }

    void UpdateBowSprite()
    {
        if (currentArrowtype == "Normal")
            bowRenderer.sprite = normalsprite;
        else if (currentArrowtype == "Double")
            bowRenderer.sprite = doublearrowsprite;
        else if (currentArrowtype == "Fast")
            bowRenderer.sprite = fastarrowsprite;
    }

}
