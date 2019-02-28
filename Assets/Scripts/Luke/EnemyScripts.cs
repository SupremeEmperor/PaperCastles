﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour {

    bool atIntersection;
    public Rigidbody2D my_rigidbody;
    Vector2 my_force;
    public float velocity_Multiplier;
    public GameObject pin;
    //temporary health management
    public int health;


    // Use this for initialization
    void Start () {
        atIntersection = false;
    }
	
	// Update is called once per frame
	void Update () {
        //my_rigidbody.AddForce(new Vector2(0, 1), ForceMode2D.Force);
        //my_rigidbody.velocity = new Vector2(0 * velocity_Multiplier, -1 * velocity_Multiplier);
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Directs the enemy towards the pin it was given in ReplacePin()
    private void FixedUpdate()
    {
        my_force = pin.transform.position - transform.position;
        my_force.Normalize();
        my_rigidbody.velocity = new Vector2(my_force.x * velocity_Multiplier, my_force.y * velocity_Multiplier);
    }

    //changes the direction towards wich the enemy goes
    public void ReplacePin(GameObject newGO)
    {
        pin = newGO;
    }

    //this deals howMuch damage to this enemy
    public void dealDamage(int howMuch)
    {
        health -= howMuch;
    }
}
