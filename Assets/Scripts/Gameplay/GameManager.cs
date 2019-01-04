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

    public float amountMinionsKilled = 0;

    private bool bosCreated = false;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        bulletText.text = gun.currentAmmo.ToString() +  "/" + gun.maxAmmo.ToString();
        if (!bosCreated) {
            timeGame += 1 * Time.deltaTime;
            if (timeGame >= timeCreateMinions)
            {
                createMinions();
                timeGame = 0;
            }
        }

        //cek kalo minion yang kebunuh udah lebih dari sama dengan 30
        if (amountMinionsKilled >= 30 && !bosCreated) {
            //munculin bos
            createBos();
            bosCreated = true;
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

    void createBos() {
        GameObject bos = (GameObject)Instantiate(Resources.Load("first_bos")) as GameObject;
        Vector3 bosPosition = new Vector3(50, 2, 115);
        bos.transform.position = bosPosition;
        
    }
}
