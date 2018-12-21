using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsTriggerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            EnemyController enemyController = this.transform.parent.gameObject.GetComponent<EnemyController>();
            enemyController.isChasePlayer = true;
            //Debug.Log("Player entering my space..");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Player")
        {
            //Debug.Log("Player exit my space..");
        }
    }
}
