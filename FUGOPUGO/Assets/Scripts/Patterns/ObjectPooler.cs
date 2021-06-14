using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{

    public Dictionary <string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;


    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    protected override void OnAwake() { _persistent = false; }
    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject getPooledObject(string tag)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool con " + tag + " non esiste");
            return null;
        }

        //Debug.Log("Elementi presenti "+ poolDictionary[tag].Count);

        if(poolDictionary[tag].Count > 0)
        {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
          //  Debug.Log("Ti sto ritornando questo elemento " + objectToSpawn);
            return objectToSpawn;
        }
        return null;
    }


    public void EnqueuePooled(string tag, GameObject obj)
    {
        poolDictionary[tag].Enqueue(obj);
    }
}
