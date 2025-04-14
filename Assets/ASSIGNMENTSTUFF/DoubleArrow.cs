using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleArrow : MonoBehaviour
{
   public GameObject arrowPrefab;
    private bool fired = false;
    private Vector3 spawnPos;

    public void Activate(Vector3 newPos)
    {
        spawnPos = newPos;
        fired = true;
    }

     void Update()
    {
        if (fired)
        {
            GameObject arrow1 = Instantiate(arrowPrefab, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
            GameObject arrow2 = Instantiate(arrowPrefab, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);
            fired = false;
            Destroy(gameObject);
        }
    }
}
