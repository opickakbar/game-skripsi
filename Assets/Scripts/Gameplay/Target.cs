﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage(float amount) {
        health -= amount;
        if (health <= 0f) {
            die();
        }
    }

    public void die() {
        Destroy(this.gameObject);
    }

}
