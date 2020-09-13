using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{

    float hp = 100f;
    float receiveDamage = 10f;

    public GameObject zombie;




    // Update is called once per frame
    void Update()
    {
        Debug.Log("Zombie HP : " + hp);
    }

    public void Hit(float dmg)
    {

        hp -= dmg;

        if (hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(zombie);
    }
}
