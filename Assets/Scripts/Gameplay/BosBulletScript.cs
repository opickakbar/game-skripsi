using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosBulletScript : MonoBehaviour {

    public float speed = 15;
    private bool getForward = false;
    private Vector3 parentForward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!getForward) {
            parentForward = this.gameObject.transform.parent.transform.forward;
            getForward = true;
        }
        this.gameObject.transform.Translate( parentForward * speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") {
            Debug.Log("bangsat");
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player") {
            PlayerController playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
            playerController.healthPlayer -= 30;
        }
    }
}
