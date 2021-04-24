using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    public bool fireOnce = true;
    public bool hasBeenTriggered = false;

    public UnityEvent triggeredEvent = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision) {
        if(fireOnce && !hasBeenTriggered){
            triggeredEvent.Invoke();
        }
    }
}
