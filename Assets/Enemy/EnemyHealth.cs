using animations.strings;
using player.animations.strings;
using UnityEngine;

namespace enemy.health
{
    public class EnemyHealth : Health
    {
        private Animator animator;

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        public override void TakeDamage(float damageAmount, Vector2 knockback)
        {
            base.TakeDamage(damageAmount, knockback);
            animator.SetTrigger(ActorAnimationStrings.hitTrigger);
        }
    }
}