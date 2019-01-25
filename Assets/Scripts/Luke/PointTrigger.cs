using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrigger : MonoBehaviour {

    public GameObject pin;

    /*
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<EnemyScripts>().ReplacePin(pin);
        Debug.Log("Trigger");
    }
    */

    public void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<EnemyScripts>().ReplacePin(pin);
        Debug.Log("Trigger");
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<EnemyScripts>().ReplacePin(pin);
    }
    */
}
