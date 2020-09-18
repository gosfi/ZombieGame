using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{

    float hp = 100f;
    // float receiveDamage = 10f;
    bool isInDistance = true;
    float distance;
    float hitTimer;
    float attackRange = 0.5f;
    float distanceRange = 0.8f;

    protected float timer = 2f;
    protected float damage = 2f;
    protected float speed = 3.5f;

    public NavMeshAgent agent;
    public GameObject zombie;
    public Animator animator;
    public Transform attackPoint;
    public Transform distancePoint;
    public LayerMask playerLayers;
    public Transform player;


    private void Start()
    {
        hitTimer = timer;
        agent.speed = speed;
    }

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

            player.Hit(damage);
            Debug.Log(players.name + "s'est fait hit");
        }
    }

    public virtual void Distance()
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
                hitTimer = timer;

            }

        }
        if (distance > 2)
        {
            animator.SetBool("isAttacking", false);
            animator.SetTrigger("Walk");
            hitTimer = timer;
            agent.speed = speed;
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
