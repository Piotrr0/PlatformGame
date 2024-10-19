using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private EnemyAI enemyAI;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;

    private float maxHealth = 100f;
    private float health = 100f;
    private float speed = 3f;
    private float attackRange = 2f;

    public float Speed { get { return speed; } }
    public BoxCollider2D BoxCollider2D { get { return boxCollider2D; } }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));
        if (!IsInAttackOrHitState())
        {
            MoveToPlayer();
            Attack();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health = Mathf.Max(health - damageAmount, 0);
        animator.SetTrigger("Hit");
    }

    private bool IsInAttackOrHitState()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit");
    }

    private void MoveToPlayer()
    {
        if (enemyAI.PlayerDetected)
        {
            enemyAI.Move(enemyAI.Player.position);
        }
    }

    private void Attack()
    {
        if(enemyAI.DistanceToPlayer <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }
}
