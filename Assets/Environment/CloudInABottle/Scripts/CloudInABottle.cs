using UnityEngine;
using UnityEngine.Events;

namespace environment.interact.cloudInABottle
{
    public class CloudInABottle : MonoBehaviour, IInteractable, IReward
    {
        [SerializeField] private UnityEvent onBottleRewardCollect;
        [SerializeField] private Transform player;
        [SerializeField] private float range = 1.0f;

        private void Update()
        {
            if (CanInteract())
            {
                Interact();
            }
        }

        public bool CanInteract()
        {
            return Input.GetKeyDown(KeyCode.E) &&
                Vector2.Distance(player.position, transform.position) <= range;
        }

        public void Interact()
        {
            CollectReward();
        }

        public void CollectReward()
        {
            onBottleRewardCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}
