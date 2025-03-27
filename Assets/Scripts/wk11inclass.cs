using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wk11inclass : MonoBehaviour
{
    SpriteRenderer sr;
    Animator annimator;
    public float speed = 2;
    public bool canRun = true;
    public AudioSource AudioSource;
    void Start()
    {
        annimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;

        annimator.SetFloat("speed", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            annimator.SetTrigger("attack");
            canRun = false;
        }

        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;

        }
    }
    public void AttackhasFinished()
    {
        Debug.Log("The atack has finished");
        canRun = true;
    }
    public void SoundThing()
    {
        AudioSource.Play();
    }

    public void SoundThing2()
    {
        AudioSource.Play();
    }

    public void SoundThing3()
    {
        AudioSource.Play();
    }
}
