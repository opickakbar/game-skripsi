using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {


    public float wanderTime, timer, wanderRadius;
    //public NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        timer = 4;
        wanderTime = 5f;
        wanderRadius = 1000;
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer >= wanderTime)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            this.GetComponent<NavMeshAgent>().SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void checkPlayerPosition()
    {

    }

    public void cekSenterPlayer()
    {

    }
}
