using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public bool gameEnding;

    public GameObject myTarget;
    public float speed;
    public float rotSpeed;
    public GameObject explosion;

    private bool rotSet;

	// Use this for initialization
	void Start () {
        gameEnding = false;
        rotSet = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (myTarget != null && rotSet == false)
        {
            this.gameObject.transform.LookAt(myTarget.transform);
            rotSet = true;
        }

		if(myTarget != null)
        {
            this.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
             this.gameObject.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime, Space.Self);
        }
	}

    public void CalcTarget(GameObject chosen)
    {
        if (chosen != null)
            myTarget = chosen;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.GetComponent<Collider>().CompareTag("Building"))
        {
            Explode();
        }

        if(other.GetComponent<Collider>().CompareTag("Shell"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Terrian"))
        {
            Explode();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        var explosionEffect = Instantiate(explosion, this.transform.position, explosion.transform.rotation);
        explosionEffect.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
    }

    void Explode()
    {
        RenderSettings.fogColor = Color.white;
        Destroy(this.gameObject);
    }
}
