using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
    private PoolableObject Prefab;
    private List<PoolableObject> AvailableObjects;
    GameObject poolObject;


    private ObjectPooler(PoolableObject Prefab, int Size)
    {
        this.Prefab = Prefab;
        AvailableObjects = new List<PoolableObject>(Size);
    }


    public static ObjectPooler CreateInstance(PoolableObject Prefab, int Size)
    {
        ObjectPooler pool = new ObjectPooler(Prefab, Size);
        GameObject poolObject = new GameObject(Prefab.name + " Pool");
        pool.CreateObjects(poolObject.transform, Size);

        return pool;
    }
    private void CreateObjects(Transform parent, int Size)
    {
        for (int i = 0; i < Size; i++)
        {
            PoolableObject poolableObject = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity, parent.transform);
            poolableObject.Parent = this;
            poolableObject.gameObject.SetActive(false);

            //AvailableObjects.Add(poolableObject); this line adds pool objects to list, however objects are added to list in ReturnObjectToPool.
            //see comment under ReturnObjectToPool
        }
    }

    public void ReturnObjecToPool(PoolableObject poolableObject)
    {
        //When pooled Objects are instantiated, they are created Active and then disabled.
        //this first wave of OnDisable, following instantiation, adds the Objects to the list through Their inherited PoolObject class

        AvailableObjects.Add(poolableObject);
        //poolableObject.transform.parent = GameObject.Find(Prefab.name + " Pool").transform;
    }

    public PoolableObject GetObject()
    {
        if (AvailableObjects.Count > 0)
        {

            PoolableObject instance = AvailableObjects[0];
            AvailableObjects.RemoveAt(0);

            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            return null;
        }
    }
}
