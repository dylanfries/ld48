using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTrap : MonoBehaviour
{
    public bool fireOnce = true;
    public bool alreadyFired = false;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (fireOnce && alreadyFired)
            return;

        if (collision.gameObject.CompareTag("Player")){
            Player p = collision.gameObject.GetComponent<Player>();
            p.KnockedDown();
            alreadyFired = true;
        }
    }
}
