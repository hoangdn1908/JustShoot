using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
    [SerializeField] private int poolSize;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private HashSet<GameObject> poolObjects = new HashSet<GameObject>();

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool() 
    {
        for (int i = 0; i < poolSize; i++) 
        {
            CreateObjects();
        }
    }

    private void CreateObjects() 
    {
        GameObject obj = Instantiate(prefabs, transform);
        obj.SetActive(false);
        pool.Enqueue(obj);
        poolObjects.Add(obj);
    }

    public GameObject GetFromPool() 
    {
        if (pool.Count == 0) CreateObjects();
        GameObject obj = pool.Dequeue();
        poolObjects.Remove(obj);
        obj.transform.SetParent(null, true);
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj) 
    {
        if (obj == null) return;
        if (poolObjects.Contains(obj)) return;
        obj.transform.SetParent(transform, true);
        obj.SetActive(false);
        pool.Enqueue(obj);
        poolObjects.Remove(obj);
    }
}
