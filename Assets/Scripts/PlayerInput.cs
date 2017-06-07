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
    public Camera cam;

    // Use this for initialization
    void Start () {
        aud1 = GetComponent<AudioSource>();
        aud1.Pause();
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = cam.ScreenPointToRay(new Vector3(scope.transform.position.x, scope.transform.position.y, 0));
        //Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        Debug.DrawRay(ray.origin, ray.direction * 250, Color.yellow);

        target.position = ray.GetPoint(250);
		
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
