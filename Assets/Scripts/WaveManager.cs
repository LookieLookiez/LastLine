using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    public GameObject bombSpawner;

    public int numBombInc;
    public int bombsCurWave;
    public int bombsDelivered;

    public float timeBetweenWaves;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(bombsDelivered == bombSpawner.GetComponent<BombSpawner>().curNumBombs)
        {
            UpdateBombSpawner();
        }

	}

    void UpdateBombSpawner()
    {
        bombsDelivered = 0;
        bombSpawner.GetComponent<BombSpawner>().curNumBombs += numBombInc;
        bombSpawner.GetComponent<BombSpawner>().waveDelay = timeBetweenWaves;
        bombSpawner.SendMessage("CreateBombs");
    }
}
