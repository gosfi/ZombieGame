using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    public bool isHit = false;

    float hp = 100f;
    float receiveDamage = 10f;
    
    bool isDead = false;

    public GameObject zombie;
    private Gun gun;

   

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Zombie HP : " + hp);
        Hit();
        Dead();
    }

    void Hit()
    {
        if (isHit)
        {
            hp -= gun.dmg;
            isHit = false;
        }
        if(hp <= 0)
        {
            isDead = true;
        }
    }

    void Dead()
    {

        if (isDead)
        {
            Destroy(zombie);  
        }

    }
}
