using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    private float jumpForce = 10f;
    private float jumpCutMultiplier = 0.3f;

    private float gravity = 1f;
    private float maxGravity = 5f;
    private float gravityIncrement = 2f;

    private Rigidbody2D body;
    private Animator animator;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
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
        const float distance = 1f;
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        return hit.collider != null;
    }

    private bool isFalling()
    {
        return body.velocity.y < 0 && !IsGrounded();
    }

}
