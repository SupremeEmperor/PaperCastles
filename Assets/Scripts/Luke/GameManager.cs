using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    public GameObject[] CastleSpawn;
    public GameObject[] EnemySpawn;
    public GameObject spawnPoint;
    public int enemySpawnCount;
    public int money = 100;
    private bool onRoad;
    private bool enemyTurn;


    private void Start()
    {
        onRoad = false;
        enemyTurn = false;
    }

    // Update is called once per frame
    void Update () {
        fireCheck();
        if(enemySpawnCount > 0 && enemyTurn)
        {
            SpawnIn();
            enemySpawnCount--;
        }
    }

    public void setTurn(bool to)
    {
        enemyTurn = to;
    }

    public void setOnRoad(bool to)
    {
        onRoad = to;
    }

    //This will spawn in the enamies
    private void SpawnIn()
    {
        if (enemyTurn)
        {
            Vector3 pos = spawnPoint.transform.position;
            pos.z = 0;
            Instantiate(EnemySpawn[0], pos, Quaternion.identity);
        }
    }



    //Checks to see if you are clicking on the screen as long as it is not the enemy turn
    private void fireCheck()
    {
        int cost = CastleSpawn[0].GetComponent<CastleCostScript>().getCost();
        if (Input.GetButtonDown("Fire1") && onRoad && money >= cost && !enemyTurn)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(CastleSpawn[0], pos, Quaternion.identity);
            money -= cost;
        }
    }
}
