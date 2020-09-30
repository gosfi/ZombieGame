﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSettings : NetworkBehaviour
{
    const float REGEN_TIME = 5f;
    const float DOWN_TIME = 20f;


    public float updateHp = 100f;
    public float maxHp = 100f;
    public bool canRevive = false;
    public bool isDown = false;
    public bool isHit = false;
    public float downTime = DOWN_TIME;
    public float reviveTime = 0f;

    public GameObject player;
    public GameObject reviveZone;
    public GameObject reviveText;
    public GameObject cameraSpectate;
    public GameObject playerDownTime;
    public GameObject playerReviveTime;
    public GameObject playerReviveCircle;

    float regenPoint = 20f;
    bool isDead = false;
    bool startTime = false;
    int receiveDamage = 10;
    float regenTime = REGEN_TIME;



    void Start()
    {

    }

    void Update()
    {
       // Debug.Log("startTime : " + startTime);

        Hit();
        Regen();
        Down();
        Revive();
        Dead();
        Test();
    }

    void Hit()
    {
        if (isHit)
        {
            updateHp -= receiveDamage;
        }
    }

    void Regen()
    {

        if (isHit)
        {
            startTime = true;
            regenTime = REGEN_TIME;
            isHit = false;

        }


        if (updateHp <= 0)
        {
            startTime = false;
            regenTime = REGEN_TIME;
        }


        if (startTime)
        {
            regenTime -= Time.deltaTime;

        }
        


        if (regenTime <= 0)
        {
            updateHp += regenPoint * Time.deltaTime;

            if (updateHp > maxHp)
            {
                updateHp = 100f;
                startTime = false;
                regenTime = REGEN_TIME;
            }
        }

        if (updateHp <= 0 && !isDead)
        {
            updateHp = 0;
            isDown = true;

        }
    }

    void Down()
    {


        if (isDown)
        {
            reviveZone.SetActive(true);
            playerDownTime.SetActive(true);
            playerReviveTime.SetActive(true);
            playerReviveCircle.SetActive(true);
            downTime -= Time.deltaTime;
            canRevive = true;
        }

        if (downTime <= 0)
        {
            reviveZone.SetActive(false);
            reviveText.SetActive(false);
            playerDownTime.SetActive(false);
            canRevive = false;
            downTime = DOWN_TIME;
            isDead = true;
            isDown = false;
        }
    }

    void Revive()
    {
        if (Input.GetKey(KeyCode.F) && canRevive)
        {
            reviveTime += 2 * Time.deltaTime;


        }
        else
        {
            reviveTime -= Time.deltaTime;

        }

        if (reviveTime <= 0)
        {
            reviveTime = 0;
        }

        if (reviveTime >= 10f)
        {
            canRevive = false;
            reviveZone.SetActive(false);
            reviveText.SetActive(false);
            playerDownTime.SetActive(false);
            playerReviveTime.SetActive(false);
            playerReviveCircle.SetActive(false);
            isDown = false;
            reviveTime = 0f;
            updateHp = 50f;
            isHit = true;
            downTime = DOWN_TIME;
        }
    }

    void Dead()
    {

        if (isDead)
        {
            Destroy(player);
            cameraSpectate.SetActive(true);
        }

    }

    void Test()
    {
        //  Debug.Log("Player HP : " + updateHp);

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
