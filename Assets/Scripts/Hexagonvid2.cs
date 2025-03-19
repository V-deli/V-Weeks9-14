using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hexagonvid2 : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    public UnityEvent onHit; //making a unity event

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    public void ChangeColour()
    {
        SpriteRenderer.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (SpriteRenderer.bounds.Contains(mousePos))
            {
                onHit.Invoke(); //new
            }
        }
    }
}
