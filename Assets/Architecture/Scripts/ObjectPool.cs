using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T prefab;
    private Transform container;
    private List<T> pool;

    public ObjectPool(T prefab, Transform container, int size)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(size);
    }

    private void CreatePool(int size)
    {
        pool = new List<T>();
        for (int i = 0; i < size; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(prefab, container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach(var elem in pool)
        {
            if (!elem.gameObject.activeInHierarchy) 
            { 
                elem.gameObject.SetActive(true);
                element = elem;
                return true;
            }
        }
        element = null;
        return false;
    }

    public bool HasFreeElement()
    {
        foreach (var elem in pool)
        {
            if (!elem.gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }

    public T GetFreeElement()
    {
        return HasFreeElement(out var element) ? element : throw new System.Exception("There is no free element in the pool");
    }
}