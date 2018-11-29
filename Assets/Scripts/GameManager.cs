using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text bulletText;
    public Slider healthBar;
    public int playerHealth;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        bulletText.text = gun.currentAmmo.ToString() +  "/" + gun.maxAmmo.ToString();

    }
}
