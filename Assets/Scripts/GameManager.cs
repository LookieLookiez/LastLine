using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject gameCore;
    public GameObject soundManager;
    public GameObject uIManager;
    public GameObject[] buildings;
    private int buildingCount;
    public Color goBackTo;

	void Start () {
        buildingCount = buildings.Length;
        
    }

	void Update () {
        RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, goBackTo, Time.deltaTime);

        var trackedHealth = GetComponent<LifeTimer>().currentHealth;

        // Lose conditions
        if(trackedHealth <= 0  || buildingCount <= 0)
        {
            Lose();
        }

	}

    void UpdateBuildingCount()
    {
        buildingCount--;
    }

    void Lose()
    {
        soundManager.GetComponent<SoundManager>().gameEnding = true;
        gameCore.GetComponent<BombSpawner>().gameEnding = true;
        gameCore.GetComponent<LifeTimer>().gameEnding = true;
        gameCore.GetComponent<PlayerInput>().gameEnding = true;
        uIManager.GetComponent<UIManager>().gameEnding = true;

    }

}
