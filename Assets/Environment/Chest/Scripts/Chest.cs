using UnityEngine;
using UnityEngine.Events;
using animations.strings;

namespace environment.interact.chest
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent onChestOpen;
        [SerializeField] private Transform player;
        [SerializeField] private float range = 1.0f;
        private bool chestOpened = false;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!chestOpened && Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.position, transform.position) <= range)
            {
                Interact();
            }
        }

        public void Interact()
        {
            onChestOpen.Invoke();
            animator.SetTrigger(ChestAnimationStrings.openChest);
        }
    }
}

