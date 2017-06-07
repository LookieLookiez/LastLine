using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {
    public Image scope;
    public Transform target;
    public float speed;

    public AudioSource aud1;
    public AudioClip move;

	// Use this for initialization
	void Start () {
        aud1 = GetComponent<AudioSource>();
        aud1.Pause();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.UpArrow))
        {
            scope.transform.Translate(Vector3.up);
            target.transform.Translate(Vector3.up * speed * Time.deltaTime);
            aud1.UnPause();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            scope.transform.Translate(Vector3.down);
            target.transform.Translate(Vector3.down * speed * Time.deltaTime);
            aud1.UnPause();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            scope.transform.Translate(Vector3.right);
            target.transform.Translate(Vector3.right * speed * Time.deltaTime);
            aud1.UnPause();
        }

        if (Input.GetKey(KeyCode.LeftArrow))

        {
            scope.transform.Translate(Vector3.left);
            target.transform.Translate(Vector3.left * speed * Time.deltaTime);
            aud1.UnPause();
        }

        if (!Input.anyKey)
        {
            aud1.Pause();
        }
        
    }
}
