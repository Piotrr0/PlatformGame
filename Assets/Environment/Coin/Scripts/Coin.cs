using UnityEngine;
using UnityEngine.Events;

namespace environment.collect.coin
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private UnityEvent onCoinCollect;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                Collect();
            }
        }

        public void Collect()
        {
            onCoinCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}