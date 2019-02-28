using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBoxTrigger : MonoBehaviour
{
    public Texture2D place;
    
    //This will change the mouse image when you can place a castle
    private void OnMouseOver()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().getPlacingCastle()) { 
            Cursor.SetCursor(place, Vector2.zero, CursorMode.Auto);
            //Debug.Log("yes Yes YES");
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().setOnRoad(true);
        }
    }


    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().setOnRoad(false);
    }
}
