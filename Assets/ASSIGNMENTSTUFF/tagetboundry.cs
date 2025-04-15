using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tagetboundry : MonoBehaviour
{
    public ArrowShooter shooter; // access this script for its arrow powerups
    public TextMeshProUGUI screenscore; // textMPRO on screen
    
    //target areas
    private int yup = 3; //the upper restriction= y axis
    private int ydown = -3; //the below restriction= y axis
    //INTENT: arrow prefabs inbetween these y coordinates && =< 6 x = score point
    private int xleft = 6; // 6= middle of target, once arrow/s =<, then score point

    private int score = 0; // Score counter


    void Start()
    {
        score = 0; // start off 0 
    }
    //-------MAIN VERISION------------------------------------------------------
    void Update()
    {
        if (shooter.allpowerups != null) //do below code if not null
        {
            // tryin 2 Loop through each arrow 
            for (int i = 0; i < shooter.allpowerups.Length; i++)
            {
                // pos of current arrow powerup
                if (shooter.allpowerups[i] != null)
                {
                    Vector2 arrow = shooter.allpowerups[i].transform.position; // position of arrow
                    // IF ARROW WITHIN TARGET AREA -------------------------------
                    if (arrow.y > ydown && arrow.y < yup && arrow.x > xleft) //these are the restrictions of the variables made above
                    {
                        score += 1; //if requirements met by the arrow, player scores 1 point
                        screenscore.text = "Score: " + score.ToString(); //convert the score to a string, updates the score on the screen
                        Debug.Log("Score: " + score); //this didn't work, never got a chance to fix it, debuglog didn't pop up too
                    }
                }
            }
        }
        else
        {
            Debug.Log("arraynotagned"); //if its null, this will pop up to tell me
        }
        if (score >= 30) //once/if the score reaches 30
        {
            screenscore.text = "WINNER!"; //this will be shown on screen
            Debug.Log("Winner! Score reset."); //debuglog to try and fix it...still does not work
            StartCoroutine(ResetscoreafterDelay()); //this starts, to reset the score back to 0 and hence restart the game
        }

        IEnumerator ResetscoreafterDelay()
        {
            yield return new WaitForSeconds(3f); //I wanted it to wait for 3 secs
            score = 0; //back to 0
            screenscore.text = "Score: " + score.ToString(); //refresh the display on screen
        }
    }
}

