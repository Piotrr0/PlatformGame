using UnityEngine;

public class Health : MonoBehaviour
{
    protected float maxHealth = 100f;
    protected float health = 100f;

    public virtual void Awake()
    {
        health = maxHealth;   
    }

    public virtual void TakeDamage(float damageAmount)
    {
        health = Mathf.Max(health - damageAmount, 0);
    }
}
