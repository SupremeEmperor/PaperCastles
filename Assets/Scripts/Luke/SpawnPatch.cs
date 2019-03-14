using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatch : MonoBehaviour
{
    public GameObject[] pin;
    private int path;
    public int upperRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        path = Random.Range(0, upperRange);
        collision.gameObject.GetComponent<EnemyScripts>().ReplacePin(pin[path]);
    }
}
