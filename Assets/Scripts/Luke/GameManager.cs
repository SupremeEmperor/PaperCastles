using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    public GameObject[] spawnees;
    public int money = 100;
    public int cost;
    private bool onRoad;


    private void Start()
    {
        onRoad = false;
    }

    // Update is called once per frame
    void Update () {
        fireCheck();
    }

    public void setOnRoad(bool to)
    {
        onRoad = to;
    }




    //Checks to see if you are clicking on the screen
    private void fireCheck()
    {
        if (Input.GetButtonDown("Fire1") && onRoad && money >= cost)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(spawnees[0], pos, Quaternion.identity);
            money -= cost;
        }
    }
}
