using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private EnemyAI enemyAI;
    private PatrolComponment patrolComponment;
    private Rigidbody2D body;
    private float speed = 3f;

    public float Speed { get { return speed; } }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
        patrolComponment = GetComponent<PatrolComponment>();
    }

    private void Start()
    {
        StartCoroutine(patrolComponment.StartPatroling(speed));
    }

    private void Update()
    {
        if (animator != null && body != null)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));
        }
        if (animator != null && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        if (enemyAI && enemyAI.PlayerDetected)
        {
            enemyAI.Move(enemyAI.Player.position, speed);
        }
    }
}
