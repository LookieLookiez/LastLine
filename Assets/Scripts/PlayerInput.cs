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

        Debug.DrawRay(ray.origin, ray.direction * 250, Color.yellow);

        float xPos = Mathf.Lerp(target.position.x, ray.GetPoint(250).x, speed * Time.deltaTime);
        float yPos = Mathf.Lerp(target.position.y, ray.GetPoint(250).y, Time.deltaTime);

        Vector3 calculatedTarget = new Vector3(xPos, yPos, ray.GetPoint(250).z);


        target.position = calculatedTarget;
		
        if(Input.GetKey(KeyCode.UpArrow))
        {
            scope.transform.Translate(Vector3.up);
            aud1.UnPause();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            scope.transform.Translate(Vector3.down);
            aud1.UnPause();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            scope.transform.Translate(Vector3.right);
            aud1.UnPause();
        }

        if (Input.GetKey(KeyCode.LeftArrow))

        {
            scope.transform.Translate(Vector3.left);
            aud1.UnPause();
        }

        if (!Input.anyKey)
        {
            aud1.Pause();
        }
        
    }
}
