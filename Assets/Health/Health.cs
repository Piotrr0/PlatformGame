using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent<float, Vector2> onHit;
    protected float maxHealth = 100f;
    protected float health = 100f;

    protected virtual void Awake()
    {
        health = maxHealth;   
    }

    public virtual void TakeDamage(float damageAmount, Vector2 knockback)
    {
        health = Mathf.Max(health - damageAmount, 0);
        onHit?.Invoke(damageAmount, knockback);
    }
}
