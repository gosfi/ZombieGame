using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    

    public float updateHp = 100f;

    float maxHp = 100f;
    float regenPoint = 20f;
    public bool isHit = false;
    bool isDead = false;
    bool startTime = false;
    int receiveDamage = 10;
    float waitTime = 5f;

    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        Regen();
        Hit();
        Dead();
        Test();
    }

    void Regen()
    {

        if (isHit)
        {
            startTime = true;
        }

        if (startTime)
        {
            waitTime -= Time.deltaTime;
        }

        if (waitTime <= 0)
        {
            updateHp += regenPoint * Time.deltaTime;

            if (updateHp > maxHp)
            {
                updateHp = 100f;
                startTime = false;
                waitTime = 5f;
            }
            if (updateHp < 0)
            {
                updateHp = 0;
            }
        }
        
       
    }

    void Hit()
    {
        if (isHit)
        {
            updateHp -= receiveDamage;
            isHit = false;
        }
    }

    void Dead()
    {
        if (updateHp <= 0)
        {
            updateHp = 0;
            isDead = true;
        }
        // if (isDead)
        // {
        //     Destroy(player);
        // }
    }

    void Test()
    {
        Debug.Log("Player HP : " + updateHp);

        //if (!isDead)
        //{
        //    Debug.Log("Player HP : " + updateHp);
        //}
        //else
        //{
        //    Debug.Log("Player is dead : " + isDead);
        //}
    }

}
