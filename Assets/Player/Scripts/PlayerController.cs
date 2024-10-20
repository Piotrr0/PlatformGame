using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;
    private Rigidbody2D body;
    private Animator animator;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSO.animator = animator;
    }

    public void onHit(float damage, Vector2 knockback)
    {
        if (body != null)
        {
            body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
        }
    }

    public void onAttack()
    {
        if (body != null)
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }
}
