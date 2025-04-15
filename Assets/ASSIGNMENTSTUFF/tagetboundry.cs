using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tagetboundry : MonoBehaviour
{
    public ArrowShooter shooter;
    Transform positionoftarget;
    Vector2 target;
    int yup =3;
    int ydown =-3;
    int xleft = 6;
    int score =0;
    public TextMeshProUGUI screenscore;
    
    void Start()  
    {
       positionoftarget = GetComponent<Transform>();
        target = GetComponent<Transform>().position;
        score = 0;
    }


    void Update()
    {
        //if an arrow shoot in the target sprite width, then point score, if not, no point score.

        //ctrl k + D to format

        //for (int i = 0; i < shooter.allpowerups.Length; i++)
        //{
        //    Vector2 arrow = shooter.allpowerups[i].transform.position;
        //    if (arrow.y > ydown && arrow.y < yup && arrow.x > xleft)
        //    {
        //        score += 1;
        //        screenscore.text = score.ToString();
        //        Debug.Log(score);
        //    }
        //}


    }
}

