using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    //Write a coroutine that makes a sprite do something (grow, move, rotate, etc) using an AnimationCurve.

    public AnimationCurve BATMANBOOGIE;
    public float SIZE;

    public float t;

    Coroutine sizeChange;
    IEnumerator value;

    void Start()
    {
        sizeChange = StartCoroutine(changeSize());
    }

    private IEnumerator changeSize()
    {
        while (true)
        {
            t += Time.deltaTime;
            if (t > 3)
            {
                t = 0;
            }
            float size = BATMANBOOGIE.Evaluate(t / 3);

            transform.localScale = Vector2.one * size;
            yield return null;
        }
    }
}