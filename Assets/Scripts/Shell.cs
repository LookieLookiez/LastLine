using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public Transform shellTarget;
    public GameObject shell;

    public AudioSource aud;
    public AudioClip fire;
    public ParticleSystem flash;

    public Transform scope;

	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            aud.PlayOneShot(fire, 1);
            flash.Play();
        }

        transform.LookAt(scope);
	}
}
