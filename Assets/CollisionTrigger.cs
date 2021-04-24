using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    public bool fireOnce = true;
    public bool hasBeenTriggered = false;

    public bool onlyPlayerTriggers = true;

    public UnityEvent triggeredEvent = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision) {
        if(fireOnce && !hasBeenTriggered){
            if(onlyPlayerTriggers){
                if(collision.gameObject.CompareTag("Player")){

                    Debug.Log(collision.gameObject.name);
                    hasBeenTriggered = true;
                    triggeredEvent.Invoke();
                }
            } else{
                Debug.Log(collision.gameObject.name);
                hasBeenTriggered = true;
                triggeredEvent.Invoke();
            }
            
        }
        else if(!fireOnce){
            triggeredEvent.Invoke();
        }
    }
}
