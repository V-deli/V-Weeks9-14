using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleArrow : MonoBehaviour
{
   public GameObject arrowPrefab;

    private void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        GameObject arrow1 = Instantiate(arrowPrefab, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
        GameObject arrow2 = Instantiate(arrowPrefab, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);

        Destroy(gameObject);
    }
}
