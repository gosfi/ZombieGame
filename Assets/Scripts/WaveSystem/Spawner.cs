﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawner : NetworkBehaviour
{
    bool canSpawn = true;
    float timer = 5f;

    public string tag;

    WaveManager wave;

    private void Awake()
    {
        wave = WaveManager.instance;
    }

    
    public void CmdSpawnMonster()
    {
        if (canSpawn)
        {
          //  GameObject obj = wave.CmdSpawnFromPool(tag, transform.position, Quaternion.identity);
           // NetworkServer.Spawn(obj);
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
