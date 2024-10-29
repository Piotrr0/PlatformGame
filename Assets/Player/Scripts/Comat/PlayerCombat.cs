using UnityEngine;
using UnityEngine.Events;
using player.animations.strings;

namespace player.combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAttack;
        private Animator animator;

        private bool _isAttacking;
        public bool isAttacking
        {
            get => animator.GetBool(PlayerAnimationStrings.isAttacking);
            private set
            {
                if (animator != null)
                    animator.SetBool(PlayerAnimationStrings.isAttacking, value);
            }
        }

        private bool canAttack
        {
            get 
            {
                return animator.GetBool(PlayerAnimationStrings.isGrounded) &&
                    !animator.GetBool(PlayerAnimationStrings.isHit);
            }
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (canAttack)
                {
                    Attack();
                }
            }
        }

        private void Attack()
        {
            isAttacking = true;
            animator.SetTrigger(PlayerAnimationStrings.attackTrigger);
            onAttack?.Invoke(); 
        }

        private void FinishAttack()
        {
            isAttacking = false;
        }
    }
}
