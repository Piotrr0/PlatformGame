using UnityEngine;
using animations.strings;
using health;

namespace player.health
{
    public class PlayerHealth : Health
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
        }

        public override void Heal()
        {
            base.Heal();
        }

        public override void Heal(float amount)
        {
            base.Heal(amount);
        }

        protected override void Die()
        {
            base.Die();
            Debug.Log("Die");
        }

        public void OnHit()
        {
            animator.SetTrigger(PlayerAnimationStrings.hitTrigger);
        }

        public void OnKillZoneEnter()
        {
            Die();
        }
    }
}
