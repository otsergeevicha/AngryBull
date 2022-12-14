using System.Collections.Generic;
using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    public List<T> Create(T[] items, int capacity)
    {
        List<T> factoryItems = new List<T>();

        if(items.Length == 0 || capacity == 0)
        {
            return null;
        }

        for(int i = 0; i < capacity; i++)
        {
            T prefab = GameObject.Instantiate(items[Random.Range(0, items.Length)], transform);
            factoryItems.Add(prefab);
        }
            
        return factoryItems;
    }
}