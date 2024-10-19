using UnityEngine;

public class EnemyHealth : Health
{
    private Animator animator;

    public override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
    }
}
