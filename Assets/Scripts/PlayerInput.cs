using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {
    public bool gameEnding;
    public GameObject uIManager;
    public GameObject soundManager;
    public GameObject gameManager;
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
    public Transform barrelOriginal;

    //Initialization
    void Start () {
        gameEnding = false;
        curShellFill = maxShellFill;
        //Set the position for barrel to move back to
        barrelOriginal.position = barrel.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //Cast ray from where middle of scope is on screen
        Ray ray = cam.ScreenPointToRay(new Vector3(scope.transform.position.x, scope.transform.position.y, 0));
        //Visualise in editor
        Debug.DrawRay(ray.origin, ray.direction * 250, Color.yellow);
        //calculate lerping point along the cast
        float xPos = Mathf.Lerp(target.position.x, ray.GetPoint(250).x, speed * Time.deltaTime);
        float yPos = Mathf.Lerp(target.position.y, ray.GetPoint(250).y, Time.deltaTime);
        //set target
        Vector3 calculatedTarget = new Vector3(xPos, yPos, ray.GetPoint(250).z);
        //Move the barrel back to original position slowly
        barrel.transform.position = Vector3.MoveTowards(barrel.transform.position, barrelOriginal.position, Time.deltaTime);

        target.position = calculatedTarget;
        //Condition so that controls are disabled on game over
		if(!gameEnding)
        {//Controlls
            if (Input.GetKey(KeyCode.UpArrow) && scope.GetComponent<RectTransform>().localPosition.y <= 215)
            {
                scope.transform.Translate(Vector3.up * (moveSpeed / 2));
            }

            if (Input.GetKey(KeyCode.DownArrow) && scope.GetComponent<RectTransform>().localPosition.y >= -215)
            {
                scope.transform.Translate(Vector3.down * (moveSpeed / 2));
            }

            if (Input.GetKey(KeyCode.RightArrow) && scope.GetComponent<RectTransform>().localPosition.x <= 430)
            {
                scope.transform.Translate(Vector3.right * moveSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && scope.GetComponent<RectTransform>().localPosition.x >= -430)

            {
                scope.transform.Translate(Vector3.left * moveSpeed);
            }
            //Fire missile
            if (Input.GetKeyDown(KeyCode.Space) && reloadTime >= timeToReload)
            {
                fireAudio.GetComponent<AudioSource>().Play();
                rocket.Play();
                reloadTime = 0;
                timeToReload += 0.01f;
                soundManager.SendMessage("PlayReload");
                //Push the barrel backwards on fire
                barrel.transform.Translate(Vector3.back);
            }
        }
        
        //Pause conditions
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause");
            uIManager.GetComponent<UIManager>().Pause();
        }
        //Limit the fire rate
        if(reloadTime < timeToReload)
        {
            reloadTime += Time.deltaTime;
        }
        //Continuously update the silhouettes
        float updatedFill = reloadTime / timeToReload;
        shellIMG.fillAmount = updatedFill;
        //Make the barrel point towards the target
        barrel.transform.LookAt(target);
    }

}
