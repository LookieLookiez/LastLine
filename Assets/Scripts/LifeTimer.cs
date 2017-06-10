using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour {

    public bool gameEnding;

    public Image soldier;
    public float maxHealth;
    public float currentHealth;

	void Start () {
        gameEnding = false;
        currentHealth = maxHealth;
	}
	
	void Update () {
        float updatedHealth = currentHealth / maxHealth;
        soldier.fillAmount = updatedHealth;
        currentHealth -= Time.deltaTime;

        if(currentHealth <= (maxHealth/4))
        {
            soldier.color = Color.red;
        }
	}
}
