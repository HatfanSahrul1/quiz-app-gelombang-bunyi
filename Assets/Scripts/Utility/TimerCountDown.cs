using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerCountDown : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] bool autoStart;
    public UnityEvent onDone;

    void Start()
    {
        if (autoStart) TriggerTimer();
    }

    public void TriggerTimer()
    {
        StopAllCoroutines();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        float t = time;
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
        }
        onDone?.Invoke();
    }
}
