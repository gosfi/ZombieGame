using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawner : NetworkBehaviour
{
    bool canSpawn = true;

    public string nametag;

    WaveManager wave;

    private void Awake()
    {
        wave = WaveManager.instance;
    }

   // [ClientRpc]
    public void CmdSpawnMonster()
    {
        if (canSpawn)
        {
            GameObject obj = wave.CmdSpawnFromPool(nametag, transform.position, Quaternion.identity);
            NetworkServer.Spawn(obj);
            wave.CmdSpawnFromPool(tag, transform.position, Quaternion.identity);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            canSpawn = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpawn = true;
        }
    }

}
