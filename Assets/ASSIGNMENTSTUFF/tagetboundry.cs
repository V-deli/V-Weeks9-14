using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tagetboundry : MonoBehaviour
{
    public ArrowShooter shooter; // script
    private Transform positionoftarget;
    public TextMeshProUGUI screenscore; // textMPRO
    ////private Vector2 target; 

    private int yup = 3;
    private int ydown = -3;
    private int xleft = 6;
    private int score = 0; // Score counter


    void Start()
    {
        positionoftarget = GetComponent<Transform>();
         //target = positionoftarget.position; 
        score = 0; // start off 0 
    }
    //-------MAIN VERISION------------------------------------------------------
    void Update()
    {
        if (shooter.allpowerups != null)
        {
            // tryin 2 Loop through each arrow 
            for (int i = 0; i < shooter.allpowerups.Length; i++)
            {
                // pos of current arrow powerup
                if (shooter.allpowerups[i] != null)
                {
                    Vector2 arrow = shooter.allpowerups[i].transform.position;
                    // IF ARROW WITHIN TARGET AREA -------------------------------
                    if (arrow.y > ydown && arrow.y < yup && arrow.x > xleft)
                    {
                        score += 1;
                        screenscore.text = "Score: " + score.ToString();
                        Debug.Log("Score: " + score);
                    }
                }
            }
        }
        else
        {
            Debug.Log("arraynotagned");
        }
        if (score >= 30)
        {
            screenscore.text = "WINNER!";
            Debug.Log("Winner! Score reset.");
            StartCoroutine(ResetscoreafterDelay());
        }

        IEnumerator ResetscoreafterDelay()
        {
            yield return new WaitForSeconds(3f);
            score = 0;
            screenscore.text = "Score: " + score.ToString();
        }
    }
}
//--------------------------------------
//ATTEMPT 2
//public GameObject[] arrows; // drag all arrow prefabs into this in Inspector
//public TextMeshProUGUI scoreText;

//private int score = 0;

//void Update()
//{
//    // Check each arrow manually — up to 10 for example
//    if (arrows.Length > 0 && arrows[0] != null)
//    {
//        if (arrows[0].transform.position.x >= 10f &&
//            arrows[0].transform.position.y > -5f &&
//            arrows[0].transform.position.y < 5f)
//        {
//            score += 1;
//            arrows[0].transform.position = new Vector3(1000f, 1000f, 0f);
//        }
//    }

//    if (arrows.Length > 1 && arrows[1] != null)
//    {
//        if (arrows[1].transform.position.x >= 10f &&
//            arrows[1].transform.position.y > -5f &&
//            arrows[1].transform.position.y < 5f)
//        {
//            score += 1;
//            arrows[1].transform.position = new Vector3(1000f, 1000f, 0f);
//        }
//    }

//    // You can repeat the above pattern for as many arrows as you need...

//    // Score check
//    if (score >= 10)
//    {
//        scoreText.text = "WINNER!";
//        score = 0;
//    }
//    else
//    {
//        scoreText.text = "Score: " + score.ToString();
//    }
//}

