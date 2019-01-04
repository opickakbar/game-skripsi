using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BosController : MonoBehaviour {

    public GameObject Player;
    public float timeFire = 2;
    public float time = 0;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.GetComponent<NavMeshAgent>().destination);
        this.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        if (Player) {
            float distance = Vector3.Distance(Player.transform.position, this.transform.position);
            if (distance <= 27) {
                time += 1 * Time.deltaTime;
                if (time > timeFire)
                {
                    fire();
                    time = 0;
                }
            }
        }
    }

    void fire() {
        GameObject bullet = Instantiate(Resources.Load("bos_bullet")) as GameObject;
        bullet.transform.parent = this.gameObject.transform;
        bullet.AddComponent<BosBulletScript>();
        bullet.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.25f, this.transform.position.z);
        //bullet.transform.Translate(Vector3.forward * 20 * Time.deltaTime);
    }

}
