using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public GameObject soundManager;
    public bool gameEnding;
    public GameObject myTarget;
    public float speed;
    public float rotSpeed;
    public GameObject explosion;
    public GameObject nuke;
    private bool rotSet;

	//initialization
	void Start () {
        gameEnding = false;
        rotSet = false;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
    }
	
	void Update () {
        //Face bomb towards target and set rotation bool
        if (myTarget != null && rotSet == false)
        {
            gameObject.transform.LookAt(myTarget.transform);
            rotSet = true;
        }
        //If has a target move towards the target
		if(myTarget != null)
        {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
             gameObject.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime, Space.Self);
        }
	}
    //Calculate which target if it hasnt already
    public void CalcTarget(GameObject chosen)
    {
        if (chosen != null)
            myTarget = chosen;
    }
    //When colliding with trigger type colliders
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().CompareTag("Building"))
        {
            other.SendMessage("HitByBomb", SendMessageOptions.DontRequireReceiver);
            Explode();
        }
        //If hit by a shell
        if(other.GetComponent<Collider>().CompareTag("Shell"))
        {
            Destroy(gameObject);
        }
    }
    //When colliding with non trigger type colliders
    void OnCollisionEnter(Collision other)
    {
        //For broken buildings that cannot be trigger type colliders
        Debug.Log(other);
        if (other.gameObject.CompareTag("Terrian") || other.gameObject.CompareTag("Building"))
        {
            Explode();
        }
        
    }
    //On collision with shell particle
    void OnParticleCollision(GameObject other)
    {
        var explosionEffect = Instantiate(explosion, transform.position, explosion.transform.rotation);
        explosionEffect.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
    //What happens when the bomb explodes
    void Explode()
    {
        //Set fog colour to white - this moves back to origninal colour from gamemanager
        RenderSettings.fogColor = Color.white;
        soundManager.SendMessage("PlayBombExplosion");
        Destroy(gameObject);
        Instantiate(nuke, transform.position, nuke.transform.rotation);
    }
}
