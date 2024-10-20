using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private UnityEvent onAttack;
    [SerializeField] private PlayerSO playerSO;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !playerSO.isAttacking)
        {
            if (playerSO.isGrounded)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        playerSO.isAttacking = true;
        onAttack?.Invoke();
    }

    private void FinishAttack()
    {
        playerSO.isAttacking = false;
    }
}
