using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {
    public GameObject waveManager;
    public GameObject soundManager;
    public bool gameEnding;
    public GameObject bomb;
    public Transform dropZone;
    public float dropRangeX;
    public float dropRangeZ;
    public int curNumBombs;
    public List<GameObject> playerBuildings = new List<GameObject>();
    public int timeBetweenBombs;
    public float waveDelay;
    public GameObject otherTarget;
    public float randomOffset;

    //Initialization
    void Start () {
        gameEnding = false;
        StartCoroutine("CreateBombs");
	}
    //Spawn bombs coroutine
    IEnumerator CreateBombs()
    {
        //Stop the sound if the game is ending
        if(!gameEnding)
        {
            soundManager.SendMessage("StartAirRaid");
        }
        
        yield return new WaitForSeconds(waveDelay);
        
        //Duplicate the list
        var newPlayerBuildingList = new List<GameObject>();
        newPlayerBuildingList.AddRange(playerBuildings.GetRange(0, playerBuildings.Count));

        //Cycle through each bomb
        for (int i = 0; i < curNumBombs; i++)
        {
            //Calculate the x and z of bomb spawn area
            var xPos = Random.Range(dropZone.position.x - dropRangeX, dropZone.position.x + dropRangeX);
            var zPos = Random.Range(dropZone.position.z - dropRangeZ, dropZone.position.z + dropRangeZ);
            //Set a random area in the zone
            var randomPos = new Vector3(xPos, dropZone.position.y, zPos);
            //Spawn a new bomb
            var newBomb = Instantiate(bomb, randomPos, bomb.transform.rotation);
            //Get a random building in the list
            var randRoll = Random.Range(0, newPlayerBuildingList.Count);

            //If there are still buildings in the list
            if (newPlayerBuildingList.Count > 0)
            {
                //Grab chosen bomb and give it a target
                newBomb.GetComponent<Bomb>().CalcTarget(newPlayerBuildingList[randRoll]);
                //Remove the targeted building
                newPlayerBuildingList.RemoveAt(randRoll);
            }
            else //If there are no buildings remaining in the list 
            {
                //Make a new target for the bomb
                var GO = new GameObject("GO");
                //Calculate its position within a range
                var x = Random.Range(otherTarget.transform.position.x - randomOffset, otherTarget.transform.position.x + randomOffset);
                var z = Random.Range(otherTarget.transform.position.z - randomOffset, otherTarget.transform.position.z + randomOffset);
                var otherPos = new Vector3(x, otherTarget.transform.position.y, z);
                //Set that new objects position
                GO.transform.position = otherPos;
                //Send the new bomb this target instead
                newBomb.GetComponent<Bomb>().CalcTarget(GO);
            }
            //Update how many bombs have been dropped
            waveManager.GetComponent<WaveManager>().bombsDelivered += 1;

            yield return new WaitForSeconds(timeBetweenBombs);

        }
        
    }

}
