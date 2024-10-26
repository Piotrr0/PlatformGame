using UnityEngine;
using enemy.controller;

namespace enemy.mushroom.controller
{
    public class MushroomController : EnemyController
    {
        private Rigidbody2D body;
        private Animator animator;

        protected override void Awake()
        {
            base.Awake();
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (animator != null && body != null)
            {
                animator.SetFloat("xVelocity", body.velocity.x);
            }
        }

        public override void OnAttack()
        {
            base.OnAttack();
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }

        public override void OnHit(float damage, Vector2 knockback)
        {
            base.OnHit(damage, knockback);
            if (animator != null && body != null)
            {
                animator.SetTrigger("Hit");
                body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
            }
        }
    }

}
