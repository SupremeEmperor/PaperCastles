using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCostScript : MonoBehaviour
{
    //change this cost in the prefab
    public int cost;

    //Returns the cost of the castle
    public int getCost()
    {
        return cost;
    }
}
