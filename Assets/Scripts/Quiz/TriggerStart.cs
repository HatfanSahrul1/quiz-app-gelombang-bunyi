using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerStart : MonoBehaviour
{
    [SerializeField] UnityEvent startEvent;

    public void StartEvent()
    {
        startEvent?.Invoke();
    }
}
