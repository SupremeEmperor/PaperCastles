using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBoxTrigger : MonoBehaviour
{

    private void OnMouseOver()
    {
        //Debug.Log("yes Yes YES");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().setOnRoad(true);
    }

    private void OnMouseExit()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().setOnRoad(false);
    }
}
