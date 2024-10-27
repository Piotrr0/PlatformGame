using UnityEngine;
using UnityEngine.Events;
using player.movement;
using player.animations.strings;

namespace player.combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAttack;
        private PlayerMovement movement;
        private Animator animator;

        public bool isAttacking
        {
            get => animator.GetBool(PlayerAnimationStrings.isAttacking);
            private set
            {
                if (animator != null)
                    animator.SetBool(PlayerAnimationStrings.isAttacking, value);
            }
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
            {
                if (movement.isGrounded)
                {
                    Attack();
                }
            }
        }

        private void Attack()
        {
            isAttacking = true;
            onAttack?.Invoke(); 
        }
    }

}
