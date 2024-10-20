using UnityEngine;
using UnityEngine.Events;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] UnityEvent onAttack;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask playerLayer;
    private EnemyAI enemyAI;
    private Animator animator;
    private float attackRange = 2f;

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
            onAttack?.Invoke();
        }
    }
}
