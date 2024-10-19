using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private Vector2 knockbak = new Vector2(0f, 0f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if(health != null )
        {
            health.TakeDamage(attackDamage, knockbak);
        }
    }
}
