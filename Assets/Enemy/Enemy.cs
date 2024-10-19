using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private float maxHealth = 100f;
    private float health = 100f;
    private float speed = 3f;

    public float Speed { get { return speed; } }
    public BoxCollider2D BoxCollider2D { get { return boxCollider2D; } }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(float damageAmount)
    {
        health = Mathf.Max(health - damageAmount, 0);
        animator.SetTrigger("Hit");
    }
}
