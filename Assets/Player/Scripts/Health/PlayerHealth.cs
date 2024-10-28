using player.animations.strings;
using UnityEngine;

namespace player.health
{
    public class PlayerHealth : Health
    {
        private Animator animator;
        public bool isHit
        {
            get => animator.GetBool(PlayerAnimationStrings.isHit);
            private set
            {
                if (animator != null)
                    animator.SetBool(PlayerAnimationStrings.isHit, value);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        public override void TakeDamage(float damageAmount, Vector2 knockback)
        {
            base.TakeDamage(damageAmount, knockback);
            isHit = true;
        }
    }
}
