using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    private Animator animator;
    private Rigidbody2D body;
    private float attackRange;

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
        animator.SetTrigger("Attack");
        body.velocity = new Vector2(0, body.velocity.y);
    }

    private void DetectHitEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D collider in hitEnemies)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(25f);
        }
    }

    private void FinishAttack()
    {
        playerSO.combatState = CombatState.Unoccupied;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
