using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D body;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    public void OnAttack()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void onHit(float damage, Vector2 knockback)
    {
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
        if (body != null)
        {
            body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
        }
    }
}
