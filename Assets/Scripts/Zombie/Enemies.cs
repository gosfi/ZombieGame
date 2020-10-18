using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class Enemies : NetworkBehaviour
{

    float hp = 100f;
    int index = 0;
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
    private Transform player;
    WaveManager wave;


    private void OnEnable()
    {
        hitTimer = timer;
        agent.speed = speed;
        wave = WaveManager.instance;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //        Debug.Log($"{player} is the player");
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
        Debug.Log("start Attack method");
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
        //        Debug.Log("start distance method");
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
        wave.reduceZombieNumber();
    }

    public void NextTarget()
    {
        index++;
        if (wave.allPlayers[index] != null)
        {
            player = wave.allPlayers[index].transform;
        }
    }
}
