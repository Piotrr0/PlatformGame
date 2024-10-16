using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
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
            Attack();
        }
    }

    private void Attack()
    {
        playerSO.combatState = CombatState.Attack;
        body.velocity = new Vector2(0, body.velocity.y);
        animator.SetTrigger("Attack");
    }

    private void FinishAttack()
    {
        playerSO.combatState = CombatState.Unoccupied;
    }
}
