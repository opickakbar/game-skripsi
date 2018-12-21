using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text bulletText;
    public Slider healthBar;
    public int playerHealth;

    public float timeCreateMinions = 6f;
    public float timeGame = 0;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        bulletText.text = gun.currentAmmo.ToString() +  "/" + gun.maxAmmo.ToString();
        timeGame += 1 * Time.deltaTime;
        if (timeGame >= timeCreateMinions) {
            createMinions();
            timeGame = 0;
        }
    }

    void createMinions() {
        for (int i = 0; i < 7; i++) {
            GameObject minion = (GameObject)Instantiate(Resources.Load("minion")) as GameObject;
            Vector3 minionPos = new Vector3(-77.85f, 1.75f, 90);
            minion.GetComponent<EnemyController>().Player = GameObject.Find("Player");
          //  Debug.Log("minion's been created!");
        }
       
    }
}
