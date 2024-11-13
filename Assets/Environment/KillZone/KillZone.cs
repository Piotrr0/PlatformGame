using UnityEngine;
using UnityEngine.Events;

namespace environment.killZone
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class KillZone : MonoBehaviour
    {
        private BoxCollider2D boxCollider;
        [SerializeField] private UnityEvent OnKillZoneEnter;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player"))
            {
                OnKillZoneEnter?.Invoke();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}