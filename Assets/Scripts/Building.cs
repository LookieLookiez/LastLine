using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public GameObject gameCore;

    public bool stillAlive;
    public bool messageSent;

	// Use this for initialization
	void Start () {
        stillAlive = true;
        messageSent = false;

    }
	
	// Update is called once per frame
	void Update () {
		
        if(!stillAlive && !messageSent)
        {
            gameCore.SendMessage("UpdateBuildingCount");
            messageSent = true;
        }
	}

    void HitByBomb()
    {
        stillAlive = false;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
