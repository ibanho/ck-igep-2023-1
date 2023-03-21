using System;
using UnityEngine;

public class DispatcherUpdate : MonoBehaviour
{
    [ContextMenu("Insert Dispatcher")]
    void InsertDispatcher()
    {
        Dispatcher.Instance.Invoke(
            () => DoSomeThing());
    }

    public void DoSomeThing()
    {
        Debug.Log($"{DateTime.Now}");
    }

    // Update is called once per frame
    void Update()
    {
        Dispatcher.Instance.InvokePending();
    }
}
