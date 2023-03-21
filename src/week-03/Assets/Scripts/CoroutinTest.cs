using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinTest : MonoBehaviour
{
    public int count = 1000;
    private Coroutine _coroutine;

    [ContextMenu("Start Coroutine")]
    public void CoroutineStart()
    {
        _coroutine = StartCoroutine(CoroutinFunc());
    }

    IEnumerator CoroutinFunc()
    {
        double dv = 0d;
        while (true) 
        { 
            for (int i = 0; i < count; i++) 
            {
                for (int j = 0; j < count; j++)
                {
                    dv += Random.Range(-1f, 1f);
                }
            }
            Debug.Log(dv);
            yield return null;
        }
    }

    [ContextMenu("Stop Coroutine")]
    public void CoroutineStop()
    {
        if (_coroutine != null)
        { 
            StopCoroutine(_coroutine);
        }
        //StopAllCoroutines();
    }
}
