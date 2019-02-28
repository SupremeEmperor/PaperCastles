using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    public GameObject[] CastleSpawn;
    public GameObject[] EnemySpawn;
    public GameObject spawnPoint;
    public int[] enemyRoundSpawnCount;
    public int money = 100;
    private bool onRoad;
    private bool enemyTurn;
    private bool placingCastle;
    private int castleType;
    private int round;
    public Text MoneyText;


    private void Start()
    {
        round = 0;
        onRoad = false;
        enemyTurn = false;
        setMoneyText();
    }

    private void setMoneyText()
    {
        MoneyText.text = "Money: " + money.ToString();
    }

    // Update is called once per frame
    void Update () {
        fireCheck();
        if(enemyRoundSpawnCount[round] > 0 && enemyTurn)
        {
            SpawnIn();
            enemyRoundSpawnCount[round]--;
        }
    }

    //Sets the enemy turn to to
    public void setTurn(bool to)
    {

        if (to)
        {
            money += (enemyRoundSpawnCount[round]/2);
            setMoneyText();
        }
        enemyTurn = to;
        placingCastle = false;
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
        if (Input.GetButtonDown("Fire1") && onRoad && money >= cost && !enemyTurn && placingCastle)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(CastleSpawn[0], pos, Quaternion.identity);
            money -= cost;
            setMoneyText();
        }
    }

    //returns true if you are currently able to place a castle
    public bool getPlacingCastle()
    {
        return placingCastle;
    }

    //set wheter or not you can place a castle
    public void setPlacingCastle(bool to)
    {
        if (!enemyTurn)
        {
            placingCastle = to;
        }
    }

    //changes the castle type to the given value
    public void setCastleType(int to)
    {
        castleType = to;
    }

    //Increments the round if the enemies are all dead
    public void nextRound()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && enemyRoundSpawnCount[round] == 0)
        {
            round++;
            enemyTurn = false;
        }
    }


}


