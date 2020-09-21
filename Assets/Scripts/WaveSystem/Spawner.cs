using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool canSpawn = true;
    float timer = 1.5f;

    public string tag;

    WaveManager wave;

    private void Awake()
    {
        wave = WaveManager.instance;
    }

    public void SpawnMonster()
    {
        if (canSpawn)
        {
            wave.SpawnFromPool(tag, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (canSpawn && timer <= 0)
        {
            wave.SpawnFromPool(tag, transform.position, Quaternion.identity);
            timer = 1.5f;
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
