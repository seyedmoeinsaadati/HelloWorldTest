using System;
using System.Collections;
using UnityEngine;

public class MonoBase : MonoBehaviour
{
    public void DelayCall(float seconds, Action callback)
    {
        if (seconds > 0.001f)
            StartCoroutine(DelayCallRoutine(seconds, callback));
        else
            callback();
    }

    private IEnumerator DelayCallRoutine(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }
}