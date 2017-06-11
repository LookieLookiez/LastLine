using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    public bool gameEnding;
    public GameObject uIManager;
    public GameObject soundManager;

    public Image scope;
    public Transform target;
    public float speed;
    public Image shellIMG;
    public float maxShellFill;
    public float curShellFill;
    public Camera cam;

    public float reloadTime;
    public float timeToReload;
    public float moveSpeed;

    public Transform shellTarget;
    public GameObject shell;
    public GameObject fireAudio;
    public ParticleSystem rocket;
    public GameObject barrel;


    // Use this for initialization
    void Start () {
        gameEnding = false;
        curShellFill = maxShellFill;
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
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            scope.transform.Translate(Vector3.down);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            scope.transform.Translate(Vector3.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))

        {
            scope.transform.Translate(Vector3.left * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && reloadTime >= timeToReload)
        {
            fireAudio.GetComponent<AudioSource>().Play();
            rocket.Play();
            reloadTime = 0;
            timeToReload += 0.01f;
            soundManager.SendMessage("PlayReload");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause");
            uIManager.GetComponent<UIManager>().Pause();
        }

        if(reloadTime < timeToReload)
        {
            reloadTime += Time.deltaTime;
        }

        float updatedFill = reloadTime / timeToReload;
        shellIMG.fillAmount = updatedFill;

        barrel.transform.LookAt(target);
    }
}
