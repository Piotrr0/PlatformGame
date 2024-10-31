using UnityEngine;
using UnityEngine.Events;

namespace environment.collect.coin
{
    public class Coin : MonoBehaviour, ICollectable
    {
        private UnityEvent OnCoinCollect;

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                Collect();
            }
        }

        public void Collect()
        {
            OnCoinCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}