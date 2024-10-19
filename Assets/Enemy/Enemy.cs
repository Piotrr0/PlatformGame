using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private float maxHealth = 100;
    private float health = 100;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health = Mathf.Max(health - damageAmount, 0);
        animator.SetTrigger("Hit");
    }
}
