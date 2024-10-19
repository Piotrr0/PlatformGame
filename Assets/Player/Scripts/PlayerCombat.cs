using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    private Animator animator;
    private Rigidbody2D body;
    [SerializeField] private float attackRange = 0.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerSO.combatState == CombatState.Unoccupied)
        {
            if (playerSO.isGrounded)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        playerSO.combatState = CombatState.Attack;
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        if(body != null)
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }

    private void DetectHitEnemies()
    {
        if(attackPoint)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D collider in hitEnemies)
            {
                EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(25f);
                }
            }
        }
    }

    private void FinishAttack()
    {
        playerSO.combatState = CombatState.Unoccupied;
    }

    private void OnDrawGizmos()
    {
        if(attackPoint)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
