using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexSpawnervid2 : MonoBehaviour
{
    public GameObject prefab;
    public Button buttontochangecolor;

    public void SpawnerHexagon()
    {
       GameObject newhexs = Instantiate(prefab, Random.insideUnitCircle * 4, transform.rotation); //rotation not rotate
        //inside unit cicle= ra. position inside a circle w radius of # being multiplied
        Hexagon hexagon = newhexs.GetComponent<Hexagonvid2>();
        
        buttontochangecolor.onClick.AddListener(hexagon.ChangeColour);
        //add listener / delicate = add a listener=listen to instuctions, or, stop listenin to instuctions
    } 

    public void StopListening()
    {
        buttontochangecolor.onClick.RemoveAllListeners();
    }
    
}
