using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{


    public float updateHp = 100f;
    public bool canRevive = false;
    public bool isDown = false;



    float maxHp = 100f;
    float regenPoint = 20f;
    float reviveTime = 0f;
    float regenTime = 10f;
    float downTime = 10f;
    bool isDead = false;
    bool startTime = false;
    int receiveDamage = 10;





    public bool isHit = false;

    public GameObject player;
    public GameObject reviveZone;
    public GameObject reviveText;


    void Start()
    {

    }

    void Update()
    {
        Debug.Log("isDown : " + isDown);

        Hit();
        Regen();
        Down();
        Revive();
        Dead();
        Test();

        Debug.Log("HP : " + updateHp);
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
            isHit = false;
        }

        if (updateHp <= 0)
        {
            startTime = false;
            regenTime = 10f;
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
                regenTime = 10f;
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
            downTime -= Time.deltaTime;
            Debug.Log("Down time remaining : " + downTime);
            canRevive = true;
        }

        if (downTime <= 0)
        {
            reviveZone.SetActive(false);
            reviveText.SetActive(false);
            canRevive = false;
            downTime = 10f;
            isDead = true;
            isDown = false;
        }
    }

    void Revive()
    {
        Debug.Log("Revive time : " + reviveTime);
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
            isDown = false;
            reviveTime = 0f;
            updateHp = 50f;
            isHit = true;
            downTime = 10f;


            Debug.Log("Player has revived!");
        }
    }

    void Dead()
    {

        if (isDead)
        {
            Destroy(player);
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
