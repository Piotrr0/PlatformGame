using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private Vector2 knockback = new Vector2(0f, 0f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if(health != null )
        {
            int direction = (int)Mathf.Sign(collision.transform.position.x - transform.position.x);
            Vector2 knockbackForce = new Vector2(knockback.x * direction, knockback.y);
            health.TakeDamage(attackDamage, knockbackForce);
        }
    }
}
