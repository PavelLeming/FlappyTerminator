using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _object;

    private int _poolCapacity = 10;
    private int _maxPoolCapacity = 10;

    protected ObjectPool<T> Objects;
    protected List<T> PooledObjects = new List<T>();

    private void Awake()
    {
        Objects = new ObjectPool<T>(
            createFunc: () => Instantiate(_object),
            actionOnGet: (poolableObject) => GetAction(poolableObject),
            actionOnRelease: (poolableObject) => poolableObject.gameObject.SetActive(false),
            actionOnDestroy: (poolableObject) => Destroy(poolableObject.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _maxPoolCapacity
            );
    }

    public void Reset()
    {
        if (PooledObjects != null)
        {
            foreach (T obj in PooledObjects.ToList())
            {
                Release(obj);
            }
        }
    }

    protected virtual void GetAction(T poolableObject)
    {

    }

    protected virtual void Release(T poolableObject)
    {
        
    }
}
