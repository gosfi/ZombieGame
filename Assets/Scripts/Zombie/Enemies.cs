using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    float hp = 100f;
    float receiveDamage = 10f;

    public GameObject zombie;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

       
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
    
        foreach(Collider players in hitPlayer)
        {
            Debug.Log(players.name + "s'est fait hit");
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Dead()
    {
        Destroy(zombie);
    }
}
