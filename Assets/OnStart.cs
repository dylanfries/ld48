using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStart : MonoBehaviour
{
    public UnityEvent onStartEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        onStartEvent.Invoke();
    }
   
}
