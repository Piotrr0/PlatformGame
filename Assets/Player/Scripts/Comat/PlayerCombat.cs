using UnityEngine;
using UnityEngine.Events;
using player.animations.strings;

namespace player.combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAttack;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();   
            }
        }

        private void Attack()
        {
            animator.SetTrigger(PlayerAnimationStrings.attackTrigger);
            onAttack?.Invoke(); 
        }
    }
}
