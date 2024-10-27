using animations.strings;
using UnityEngine;

namespace enemy.health
{
    public class EnemyHealth : Health
    {
        private Animator animator;

        public override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        public override void TakeDamage(float damageAmount, Vector2 knockback)
        {
            base.TakeDamage(damageAmount, knockback);
            if (animator != null)
            {
                animator.SetBool(ActorAnimationStrings.isHit, true);
            }
        }
    }
}