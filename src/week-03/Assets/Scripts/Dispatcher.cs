using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDispatcher
{
    void Invoke(Action fn);
}

public class Dispatcher : IDispatcher
{
    private static Dispatcher m_instance;
    public static Dispatcher Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new Dispatcher();
            }

            return m_instance;
        }
    }

    public List<Action> pending = new List<Action>();

    public void Invoke(Action fn)
    {
        lock (pending) 
        { 
            pending.Add(fn);
        }
    }

    public void InvokePending()
    {
        lock (pending) 
        { 
            foreach (Action fn in pending) 
            { 
                fn();
            }
            pending.Clear();
        }
    }
}

