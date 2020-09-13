using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public EnemySettings zombie;



    public void Hit()
    {
        zombie.isHit = true;
    }
}
