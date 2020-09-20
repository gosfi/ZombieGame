using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool canSpawn = true;
    float timer = 0.5f;

    public string tag;

    WaveManager wave;

    private void Start() {
        wave = WaveManager.instance;
    }

    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;

        if (canSpawn && timer <= 0)
        {
            wave.SpawnFromPool(tag, transform.position, Quaternion.identity); 
            timer = 0.5f;
        }
        Debug.Log(timer);
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
