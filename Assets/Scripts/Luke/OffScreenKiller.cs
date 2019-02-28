using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenKiller : MonoBehaviour
{
    // Destroys any game objects that enter the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
