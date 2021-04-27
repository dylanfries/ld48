using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStart : MonoBehaviour
{
    public UnityEvent onStartEvent = new UnityEvent();
    public UnityEvent onDelayedStart = new UnityEvent();
    public float delayTimer = 6;

    // Start is called before the first frame update
    void Start()
    {
        onStartEvent.Invoke();
        StartCoroutine(DelayedEvent(delayTimer));
    }

    private IEnumerator DelayedEvent(float t){
        yield return new WaitForSeconds(t);
        onDelayedStart.Invoke();
    }
   
}
