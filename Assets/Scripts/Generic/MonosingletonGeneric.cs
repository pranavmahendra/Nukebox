using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonosingletonGeneric<T> : MonoBehaviour where T : MonosingletonGeneric<T> 
{
    public static T instance;
    private static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(this);
        }
    }
}
