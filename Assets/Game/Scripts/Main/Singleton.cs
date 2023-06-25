using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
    where T : Component
{
    [SerializeField] private bool _dontDestroyOnLoad;

    private static T _instance;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if (_instance != null)
            throw new Exception($"Singleton error: scene has duplicate of singleton type {GetType()}");

        _instance = FindObjectOfType<T>();

        if (_dontDestroyOnLoad)
            DontDestroyOnLoad(this);
    }

    protected virtual void OnDestroy()
    {
        _instance = null;
    }
}