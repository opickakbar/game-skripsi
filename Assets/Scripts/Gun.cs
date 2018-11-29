using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 8;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public int maxAmmo = 20;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Animator animator;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect, Player;

	// Use this for initialization
	void Start () {
        muzzleFlash.Stop();
        currentAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(reload());
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            muzzleFlash.gameObject.SetActive(false);
        }

        if (isReloading == true) {
            muzzleFlash.gameObject.SetActive(false);
            return;
        }

        if (currentAmmo <= 0f) {
            StartCoroutine(reload());
            return;
        }


        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1 / fireRate;
            shoot();
        }
	}

    IEnumerator reload() {

        Debug.Log("Reloading...");

        isReloading = true;

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        isReloading = false;

        Debug.Log("finish reload");

        currentAmmo = maxAmmo;
    }

    void shoot() {

        muzzleFlash.gameObject.SetActive(true);

        currentAmmo--;

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();

            Transform targetTransform = hit.transform;

            //ambil enemy controller lewat parent (karna dia detect nya mesh yg didalemnya
            try
            {
                if (targetTransform.parent != null) {
                    EnemyController enemyController = targetTransform.parent.GetComponent<EnemyController>();
                    if (enemyController != null) {
                        enemyController.isChasePlayer = true;
                        enemyController.takeDamage(damage);
                    }
                }
                
            }
            catch (UnityException ex) {

            }

            if (target != null) {
                target.takeDamage(damage);

            }

            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
    }
}
