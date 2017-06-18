using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Small script for particle effect
public class FadeLight : MonoBehaviour {
    public Light thisLight;
	//Initialization
	void Start () {
        thisLight = GetComponent<Light>();
        Invoke("DestroySelf", 10);
	}
	
	// Update is called once per frame
	void Update () {
        //Lerp the intensity back down to simulate nuke
        thisLight.intensity = Mathf.Lerp(thisLight.intensity, 0f, Time.deltaTime);
    }

    void DestroySelf()
    {
        //Dont keep the light in scene for too long
        Destroy(gameObject);
    }
}
