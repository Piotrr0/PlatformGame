using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask playerLayer;
    private EnemyAI enemyAI;
    private Animator animator;

    private float attackRange = 2f;
    private float attackSize = 0.5f;


    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator != null && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (enemyAI != null && enemyAI.DistanceToPlayer <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void DetectHitPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(10f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackSize);
    }
}
