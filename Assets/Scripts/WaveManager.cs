using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    public GameObject bombSpawner;
    public int numBombInc;
    public int bombsCurWave;
    public int bombsDelivered;
    public float timeBetweenWaves;
	
	// Update is called once per frame
	void Update () {
		//Update when bombs have been delivered
        if(bombsDelivered == bombSpawner.GetComponent<BombSpawner>().curNumBombs)
        {
            UpdateBombSpawner();
        }
	}
    
    void UpdateBombSpawner()
    {
        //Reset bombsDelivered
        bombsDelivered = 0;
        //Increase number of bombs 
        bombSpawner.GetComponent<BombSpawner>().curNumBombs += numBombInc;
        //Set wave delay
        bombSpawner.GetComponent<BombSpawner>().waveDelay = timeBetweenWaves;
        bombSpawner.SendMessage("CreateBombs");
    }
}
