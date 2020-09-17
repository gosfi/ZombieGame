using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static WaveManager instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionnary;

    private void Start()
    {
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionnary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
        if (!poolDictionnary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist");
            return null;
        }

        GameObject objToSpawn = poolDictionnary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = pos;
        objToSpawn.transform.rotation = rotation;

        poolDictionnary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}
