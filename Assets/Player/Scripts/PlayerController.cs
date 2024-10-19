using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void onHit(float damage, Vector2 knockback)
    {
        body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
        Debug.Log("onHit");
    }
}
