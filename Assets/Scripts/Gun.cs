using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 8;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

	// Use this for initialization
	void Start () {

        muzzleFlash.Stop();
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButton(0)) {
            shoot();
            Debug.Log("Button Down!!");
        }

        if (Input.GetMouseButtonUp(0)) {
            muzzleFlash.gameObject.SetActive(false);
        }

	}

    void shoot() {

       

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null) {
                target.takeDamage(damage);
            }

        }

        muzzleFlash.gameObject.SetActive(true);

        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
