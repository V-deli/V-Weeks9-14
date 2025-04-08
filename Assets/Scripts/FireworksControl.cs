using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksControl : MonoBehaviour
{
    public ParticleSystem fireworks;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireworks.gameObject.SetActive(!fireworks.gameObject.activeInHierarchy);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (fireworks.isPlaying == true)
            {
                fireworks.Stop();
            }
            else
            {
                fireworks.Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            fireworks.Emit(10);
        }
    }
}
