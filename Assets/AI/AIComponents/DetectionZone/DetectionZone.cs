using UnityEngine;
using UnityEngine.Events;

namespace ai.components.detectionZone
{
    public class DetectionZone : MonoBehaviour
    {
        [SerializeField] private UnityEvent onZoneEnter;
        [SerializeField] private UnityEvent onZoneExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            onZoneEnter.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            onZoneExit.Invoke();
        }
    }
}