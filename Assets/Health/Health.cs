using UnityEngine;
using UnityEngine.Events;

namespace health
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private UnityEvent<float, Vector2> onHit;
        [SerializeField] private UnityEvent onDie;
        [SerializeField] private UnityEvent<float> onHealthChanged;

        [SerializeField] protected float maxHealth = 100f;
        [SerializeField] protected float health = 100f;

        public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }

        protected virtual void Awake()
        {
            Heal();
        }

        public virtual void TakeDamage(float damageAmount, Vector2 knockback)
        {
            health = Mathf.Max(health - damageAmount, 0);
            onHit?.Invoke(damageAmount, knockback);

            if (health <= 0)
            {
                health = 0;
                Die();
            }
            onHealthChanged?.Invoke(health);
        }

        protected virtual void Die()
        {
            onDie?.Invoke();
        }

        public virtual void Heal()
        {
            health = maxHealth;
            onHealthChanged?.Invoke(health);
        }

        public virtual void Heal(float amount)
        {
            health = Mathf.Min(health + amount, maxHealth);
            onHealthChanged?.Invoke(health);
        }
    }
}
