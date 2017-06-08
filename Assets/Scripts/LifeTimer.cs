using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour {

    public Image soldier;
    public float maxHealth;
    public float currentHealth;

	void Start () {
        currentHealth = maxHealth;
	}
	
	void Update () {
        float updatedHealth = currentHealth / maxHealth;
        soldier.fillAmount = updatedHealth;
        currentHealth -= Time.deltaTime;
	}
}
