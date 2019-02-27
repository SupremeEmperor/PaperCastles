using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHealth : MonoBehaviour {

    public int health;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //destroys gameobject if health is <= 0
		if(health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    //Takes damage when an enemy enters the trigger
    private void OnTriggerStay2D(Collider2D other)
    {
        //takes damage if enemy is near
        if(other.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
