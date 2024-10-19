using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private EnemyAI enemyAI;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;

    private float speed = 3f;

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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        if (enemyAI.PlayerDetected)
        {
            enemyAI.Move(enemyAI.Player.position);
        }
    }
}
