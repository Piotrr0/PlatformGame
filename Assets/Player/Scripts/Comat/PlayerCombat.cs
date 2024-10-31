using UnityEngine;
using UnityEngine.Events;
using animations.strings;

namespace player.combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAttack;
        private Animator animator;

        [SerializeField] bool exhausted = false; // true when player finishes attack combo
        [SerializeField] private float recoveryComboTime = 0.5f;
        private float recoveryComboTimer = 0.5f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !exhausted)
            {
                Attack();   
            }
        }

        private void Attack()
        {
            animator.SetTrigger(PlayerAnimationStrings.attackTrigger);
            onAttack?.Invoke(); 
        }

        private void Recovery()
        {
            if (exhausted)
            {
                recoveryComboTimer -= Time.deltaTime;
                if (recoveryComboTimer >= 0)
                {
                    recoveryComboTimer = recoveryComboTime;
                    exhausted = false;
                }
            }
        }
    }
}
