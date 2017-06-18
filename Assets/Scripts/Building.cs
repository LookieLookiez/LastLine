using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    public GameObject gameCore;
    public GameObject myBroken;
    public List<GameObject> children = new List<GameObject>();
    public Transform offScreenPos;
    public bool stillAlive;
    public bool messageSent;

	//Initialization
	void Start () {
        stillAlive = true;
        messageSent = false;

                            //number of childern it has
        for (int i = 0; i < myBroken.transform.childCount; i++)
        {
            //Loop through and add children to the list
            children.Add(myBroken.transform.GetChild(i).gameObject);      
        }
    }
	
	// Update is called once per frame
	void Update () {
		//If dead notify gamemanager
        if(!stillAlive && !messageSent)
        {
            gameCore.SendMessage("UpdateBuildingCount");
            messageSent = true;
        }
	}
    //When bomb hits building
    void HitByBomb()
    {
        stillAlive = false;
        //Organisation for the broken building
        myBroken.transform.position = gameObject.transform.position;
        myBroken.transform.rotation = gameObject.transform.rotation;
        gameObject.transform.position = offScreenPos.position;
        
        foreach (var child in children)
        {
            //Remove the glue (in a sense)
            var Rb = child.GetComponent<Rigidbody>();
            Rb.constraints = RigidbodyConstraints.None;
        }
    }
}
