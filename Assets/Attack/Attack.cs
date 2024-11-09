using UnityEngine;
using health;

namespace attack
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] protected float attackDamage = 10f;
        [SerializeField] protected Vector2 knockback = new Vector2(0f, 0f);

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                int direction = (int)Mathf.Sign(collision.transform.position.x - transform.position.x);
                Vector2 knockbackForce = new Vector2(knockback.x * direction, knockback.y);
                health.TakeDamage(attackDamage, knockbackForce);
            }
        }

        protected virtual void Update()
        {

        }
    }
}
