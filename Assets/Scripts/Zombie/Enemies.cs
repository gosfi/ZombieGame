using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    const float HIT_TIMER = 2f;

    float hp = 100f;
   // float receiveDamage = 10f;
    bool isInDistance = true;
    float hitTimer = HIT_TIMER;
    float distance;

    public NavMeshAgent agent;
    public GameObject zombie;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public Transform distancePoint;
    public float distanceRange = 0.5f;
    public Transform player;




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
        animator.SetBool("isAttacking", true);
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
        distance = Vector3.Distance(distancePoint.position, player.position);


        Collider[] distancePlayer = Physics.OverlapSphere(distancePoint.position, distanceRange, playerLayers);

        foreach (Collider players in distancePlayer)
        {
            if (distance > 2)
            {

                break;

            }
            agent.speed = 0;
            hitTimer -= Time.deltaTime;
            if (isInDistance)
            {
                
                Attack();
                isInDistance = false;
            }
            if (hitTimer <= 0)
            {

                Attack();
                hitTimer = HIT_TIMER;

            }

        }
        if (distance > 2)
        {
            animator.SetBool("isAttacking", false);
            animator.SetTrigger("Walk");
            hitTimer = HIT_TIMER;
            agent.speed = 3.3f;
            isInDistance = true;

        }
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
