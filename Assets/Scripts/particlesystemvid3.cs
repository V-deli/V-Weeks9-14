using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesystemvid3 : MonoBehaviour
{
    public ParticleSystem bats;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bats.gameObject.SetActive(bats.gameObject.activeInHierarchy); //new
        }
        if(Input.GetMouseButton(0))
        {
            if(bats.isPlaying ==true)
            {
                bats.Stop();
            }
            else
            {
                bats.Play();
            }
        }

        if (Input.GetMouseButton(1))
        {
            bats.Emit(Random.Range(5,10)); //new
        }
    }
}
