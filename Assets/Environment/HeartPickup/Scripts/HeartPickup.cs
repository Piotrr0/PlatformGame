using UnityEngine;
using UnityEngine.Events;

namespace environment.collect.heartPickup
{
    public class HeartPickup : MonoBehaviour, ICollectable
    {
        [SerializeField] UnityEvent<float> OnHeartPickup;
        [SerializeField] private float healValue;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                Collect();
            }
        }

        public void Collect()
        {
            OnHeartPickup?.Invoke(healValue);
            Destroy(gameObject);
        }
    }
}
