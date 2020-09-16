using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    const float HIT_TIMER = 2f;

    float hp = 100f;
    float receiveDamage = 10f;
    bool isInDistance = false;
    float hitTimer = HIT_TIMER;
    bool stopMoving = false;

    public NavMeshAgent agent;
    public GameObject zombie;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public Transform distancePoint;
    public float distanceRange = 0.5f;




    // Update is called once per frame
    void Update()
    {
        Distance();
        


    }

    public void Hit(float dmg)
    {

        hp -= dmg;

        if (hp <= 0)
        {
            Dead();
        }
    }

    void Attack()
    {


        animator.SetTrigger("Attack");

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);

        foreach (Collider players in hitPlayer)
        {
            
            PlayerMovement player = players.GetComponent<PlayerMovement>();
            
            player.Hit(2);
            Debug.Log(players.name + "s'est fait hit");
        }

    }

    void Distance()
    {
        Collider[] distancePlayer = Physics.OverlapSphere(distancePoint.position, distanceRange, playerLayers);

        foreach (Collider players in distancePlayer)
        {
            agent.speed = 0;

            hitTimer -= Time.deltaTime;

            if(hitTimer <= 0)
            {
                Attack();
                hitTimer = HIT_TIMER;
            }
            
        }
        Debug.Log("Player hit distance = " + isInDistance);
    }

    

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        if (distancePoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(distancePoint.position, distanceRange);
    }

    void Dead()
    {
        Destroy(zombie);
    }
}
