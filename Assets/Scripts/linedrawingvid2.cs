using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linedrawingvid2 : MonoBehaviour
{
    public LineRenderer lr;
    public List<Vector2> Listofpoints;

    private void Start()
    {
       //lr.positionCount()
       //lr.SetPosition
       Listofpoints = new List<Vector2>();
        lr.positionCount = 0;
        lr = GetComponent<LineRenderer>();

    }

    private void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Listofpoints.Add(newPosition);

            lr.positionCount ++;
            lr.SetPosition(lr.positionCount -1, newPosition);
        }

       if (Input.GetMouseButtonDown(1))
        {
            {
                Listofpoints = new List<Vector2>();
                lr.positionCount = 0;
            }
        }
    }
}
