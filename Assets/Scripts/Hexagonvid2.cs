using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagonvid2 : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    public void ChangeColour()
    {
        SpriteRenderer.color = Random.ColorHSV();
    }
}
