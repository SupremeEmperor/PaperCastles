using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionScript : MonoBehaviour {

    public GameObject[] pin;
    private int path;

    private void Start()
    {
        path = 0;
    }

    private void Update()
    {
        path = Random.Range(0, 2);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<EnemyScripts>().ReplacePin(pin[path]);
        //Debug.Log("Trigger");
    }

}
