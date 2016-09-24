using UnityEngine;
using System.Collections;

public abstract class SingletonBehaviour<Interface> : MonoBehaviour
    where Interface : class
{
    private static Interface _instance = null;
    public static Interface instance { get { return _instance; } }

    void Awake()
    {
        System.Diagnostics.Debug.Assert(this is Interface);

        _instance = this as Interface;
        //DontDestroyOnLoad(gameObject);
        OnAwake();
    }

    protected virtual void OnAwake()
    {
    }
}