using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Slider healthBar;
    public float healthPlayer = 100;
    public GameObject panel_gameover;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = healthPlayer / 100;
        if (healthPlayer <= 0) {
            panel_gameover.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "minion")
        {
            healthPlayer -= 0.5f;
        }
    }
}
