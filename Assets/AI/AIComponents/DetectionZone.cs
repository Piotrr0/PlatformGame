using UnityEngine;
using UnityEngine.Events;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private UnityEvent onZoneEnter;
    [SerializeField] private UnityEvent onZoneExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DetectionZone"))
        {
            onZoneEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DetectionZone"))
        {
            onZoneExit.Invoke();
        }
    }
}
