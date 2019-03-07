﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderScript : MonoBehaviour
{
    public float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScripts>().MultiplyVelocity(multiplier);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<EnemyScripts>().baseVelocity();
    }
}
