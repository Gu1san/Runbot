using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolAPI : MonoBehaviour
{
    public static PoolAPI instance;
    [SerializeField] GameObject objectToInstance;
    public bool collectionChecks = true;
    public int maxPoolSize = 30;
    IObjectPool<GameObject> pool;
    public IObjectPool<GameObject> Pool
    {
        get
        {
            if (pool == null)
            {
                pool = new ObjectPool<GameObject>(CreatePooledItem,
                    OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
                    collectionChecks, 10, maxPoolSize);
            }
            return pool;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    GameObject CreatePooledItem()
    {
        GameObject go = Instantiate(objectToInstance, Vector3.zero, Quaternion.identity);
        return go;
    }

    // Called when an item is returned to the pool using Release
    void OnReturnedToPool(GameObject go)
    {
        go.SetActive(false);
    }

    // Called when an item is taken from the pool using Get
    void OnTakeFromPool(GameObject go)
    {
        go.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    void OnDestroyPoolObject(GameObject go)
    {
        Destroy(go);
    }
}
