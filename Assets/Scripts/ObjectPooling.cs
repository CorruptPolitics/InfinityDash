using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{

    public GameObject poolObject;

    public int poolAmount;

    List<GameObject> poolObjects;

    // Use this for initialization
    void Start()
    {

        poolObjects = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }

    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        GameObject obj = Instantiate(poolObject);
        obj.SetActive(false);
        poolObjects.Add(obj);
        return obj;

    }
}
