using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    public GameObject[] spawnees;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(spawnees[0], pos, Quaternion.identity);
        }
    }
}
