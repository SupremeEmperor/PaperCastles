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
    public Text RoundText;
    public int extraRoundMoney;
    public int extraRoundEnemies;


    private void Start()
    {
        round = 0;
        onRoad = false;
        enemyTurn = false;
        setMoneyText();
        setRoundText();
    }

    private void setMoneyText()
    {
        if(MoneyText != null)
            MoneyText.text = "Money: " + money.ToString();
    }

    private void setRoundText()
    {
        if (MoneyText != null)
            RoundText.text = "Round: " + (round + 1);
    }

    // Update is called once per frame
    void Update () {
        fireCheck();
        if (round >= enemyRoundSpawnCount.Length)
        {
            round = enemyRoundSpawnCount.Length - 1;
            enemyRoundSpawnCount[round] = extraRoundEnemies += 100;
        }
        if(enemyRoundSpawnCount[round] > 0 && enemyTurn)
        {
            SpawnIn();
            enemyRoundSpawnCount[round]--;
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null && enemyRoundSpawnCount[round] == 0)
        {
            round++;
            setRoundText();
            enemyTurn = false;

        }
    }

    public void eternalFoes()
    {
        enemyRoundSpawnCount[round]++;
    }

    //Sets the enemy turn to to
    public void setTurn(bool to)
    {

        if (to && to != enemyTurn)
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
        if (Input.GetButtonDown("Fire1") && onRoad && money >= (castleType + 1) * 10 && !enemyTurn && placingCastle)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            Instantiate(CastleSpawn[castleType], pos, Quaternion.identity);
            money -= (castleType + 1)*10;
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
        
    }


}


