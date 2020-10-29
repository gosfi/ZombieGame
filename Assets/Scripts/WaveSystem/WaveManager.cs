using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Player;
using System.Linq;
using UnityEngine.SceneManagement;


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

    public PlayerSpawnSystem spawnSystem;

    public int waveNumber;
    public int nbOfZombieInWave;
    public bool IsInWave = false;

    public Spawner[] spawners;

    float timer = 30f;
    public List<Pool> pools;
    private GameObject[] players;

    public List<PlayerMovement> allPlayers;
    public Dictionary<string, Queue<GameObject>> poolDictionnary;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var obj in players)
        {
            allPlayers.Add(obj.GetComponent<PlayerMovement>());
        }

        nbOfZombieInWave = 5;
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();

        CmdPoolThing();

    }
    
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !IsInWave)
        {
            StartWave();
        }

        checkIfAllPlayersAreDead();
    }
    
    private void CmdPoolThing()
    {
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
    
    private void checkIfAllPlayersAreDead()
    {
        int nbOfDeaths = 0;
        foreach (var player in allPlayers)
        {
            if (player.isDead)
            {
                nbOfDeaths++;
            }
        }
        Debug.Log("NOMBRE DE MORT : " + nbOfDeaths);
        Debug.Log("NOMBRE DE PLAYER DANS ALLPLAYERS : " + allPlayers.Count);
        if (nbOfDeaths == allPlayers.Count)
        {

           // NetworkManagerLobby.Shutdown();
            NetworkManager.Shutdown();
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("RaphMenuOnline");

        }
    }
    
    public GameObject CmdSpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
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

    public void ReduceZombieNumber()
    {
        nbOfZombieInWave--;

        if (nbOfZombieInWave == 0)
        {
            EndTheWave();
        }
    }

    private void EndTheWave()
    {
        foreach (var obj in allPlayers)
        {
            if (obj.isDead || obj.isDown)
            {
                obj.Respawn();
            }
        }
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


                spawn.CmdSpawnMonster();

            }
        }
    }
}
