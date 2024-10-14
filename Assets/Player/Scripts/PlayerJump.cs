using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    private float jumpForce = 10f;
    private float jumpCutMultiplier = 0.3f;

    private float gravity = 1f;
    private float maxGravity = 5f;
    private float gravityIncrement = 2f;

    private bool isGrounded;

    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Debug.Log(IsGrounded());
        JumpButton();
        UpdateGravity();
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * jumpCutMultiplier);
        }
    }

    private void Jump()
    {
        if (body != null && IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }

    private void UpdateGravity()
    {
        if (isFalling())
        {
            gravity = Mathf.Min(gravity + gravityIncrement * Time.deltaTime, maxGravity);
        }
        else
        {
            gravity = 1f;
        }

        if (body)
        {
            body.gravityScale = gravity;
        }
    }

    private bool IsGrounded()
    {
        if (boxCollider2D == null) return false;
        const float distance = 0.1f;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, direction, distance, groundLayer);
        return hit.collider != null;
    }

    private bool isFalling()
    {
        return body.velocity.y < 0 && !IsGrounded();
    }
}
