using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;
    private Animator animator;
    private Rigidbody2D body;

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

    private void FinishAttack()
    {
        playerSO.combatState = CombatState.Unoccupied;
    }
}
