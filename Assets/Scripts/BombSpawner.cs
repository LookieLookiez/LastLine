using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

    public bool gameEnding;

    public GameObject bomb;
    public Transform dropZone;
    public float dropRangeX;
    public float dropRangeZ;
    public int curNumBombs;
    public List<GameObject> playerBuildings = new List<GameObject>();
    public int timeBetweenBombs;

    public GameObject otherTarget;
    public float randomOffset;

	void Start () {
        gameEnding = false;
        StartCoroutine("CreateBombs");
	}

    IEnumerator CreateBombs()
    {
        for (int i = 0; i < curNumBombs; i++)
        {
            var xPos = Random.Range(dropZone.position.x - dropRangeX, dropZone.position.x + dropRangeX);
            var zPos = Random.Range(dropZone.position.z - dropRangeZ, dropZone.position.z + dropRangeZ);

            var randomPos = new Vector3(xPos, dropZone.position.y, zPos);

            var newBomb = Instantiate(bomb, randomPos, bomb.transform.rotation);

            var randRoll = Random.Range(0, playerBuildings.Count);

            if (playerBuildings.Count > 0)
            {
                newBomb.GetComponent<Bomb>().CalcTarget(playerBuildings[randRoll]);
                playerBuildings.RemoveAt(randRoll);
            }
            else
            {
                var GO = new GameObject("GO");

                var x = Random.Range(otherTarget.transform.position.x - randomOffset, otherTarget.transform.position.x + randomOffset);
                var z = Random.Range(otherTarget.transform.position.z - randomOffset, otherTarget.transform.position.z + randomOffset);
                var otherPos = new Vector3(x, otherTarget.transform.position.y, z);

                GO.transform.position = otherPos;

                newBomb.GetComponent<Bomb>().CalcTarget(GO);
            }
            

            yield return new WaitForSeconds(timeBetweenBombs);

        }
        
    }

}
