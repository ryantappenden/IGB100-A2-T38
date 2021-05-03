using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    public GameObject mainCamera;

    //UI Elements
    public Slider healthbar;

	// Use this for initialization
	void Start () {
        maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void takeDamage(float dmg) {
        health -= dmg;


        healthbar.value = (health / maxHealth);
        //healthbar.value = (health / maxHealth);       //Uncomment this line of code when healthbar is implemented!

        if (health <= 0) {
            mainCamera.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
