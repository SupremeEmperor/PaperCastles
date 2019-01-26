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
		if(health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Staying");
        if(other.gameObject.tag == "Enemy")
        {
            health -= 1;
            Debug.Log("Hurting");
        }
    }
}
