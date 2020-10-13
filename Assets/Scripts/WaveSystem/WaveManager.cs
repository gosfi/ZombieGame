using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Player;

public class WaveManager : NetworkBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static WaveManager instance;

    public int waveNumber;
    public int nbOfZombieInWave;
    public bool IsInWave = false;

    public List<PlayerMovement> players;

    public Spawner[] spawners;

    float timer = 45f;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionnary;

    private void Start()
    {

        nbOfZombieInWave = 5;
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

        StartWave();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer <= 0 && !IsInWave)
        {
            StartWave();
        }
        else
        {
            return;
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

    public void reduceZombieNumber()
    {
        nbOfZombieInWave--;

        if (nbOfZombieInWave == 0)
        {
            EndTheWave();
        }
    }

    private void EndTheWave()
    {
        waveNumber++;
        nbOfZombieInWave = 5 * waveNumber;
        timer = 45f;
        IsInWave = false;
    }


    private void StartWave()
    {
        IsInWave = true;
        for (int i = 0; i < nbOfZombieInWave; ++i)
        {
            foreach (Spawner spawn in spawners)
            {
                spawn.SpawnMonster();
            }
        }
    }
}
