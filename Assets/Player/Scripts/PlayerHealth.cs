using UnityEngine;

public class PlayerHealth : Health
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void TakeDamage(float damageAmount, Vector2 knockback)
    {
        base.TakeDamage(damageAmount, knockback);
    }
}
