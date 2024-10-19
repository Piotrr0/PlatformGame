using UnityEngine;

public class PlayerHealth : Health
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        Debug.Log(health);
    }
}
