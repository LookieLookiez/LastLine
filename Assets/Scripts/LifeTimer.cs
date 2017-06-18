using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour {
    public bool gameEnding;
    public Image soldier;
    public float maxHealth;
    public float currentHealth;

    //Initialization
	void Start () {
        gameEnding = false;
        currentHealth = maxHealth;
	}
	
	void Update () {
        //Se the value to work with fillAmount
        float updatedHealth = currentHealth / maxHealth;
        //Set the fill of the soldier silhouette
        soldier.fillAmount = updatedHealth;
        //Move the health down at a constant
        currentHealth -= Time.deltaTime;
        //Once 3/4 of the way there set the silhouette colour to red
        if(currentHealth <= (maxHealth/4))
        {
            soldier.color = Color.red;
        }
	}
}
