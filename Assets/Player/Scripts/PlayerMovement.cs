using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;

    private float horizontalInput;
    private float moveSpeed = 7f;
    private bool facingRight = true;

    private float gravity = 1f;
    private float maxGravity = 5f;
    private float gravityIncrement = 2f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        UpdateGroundedFalling();
        ProcessMovementInput();
        UpdateGravity();
        if (CheckFlip() && !playerSO.isAttacking)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(!playerSO.isAttacking)
        {
            Move();
        }
    }

    private void Move()
    {
        if (body != null)
        {
            Vector2 velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);
            body.velocity = velocity;
            playerSO.currentVelocity = velocity;
        }
    }

    private void ProcessMovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private bool CheckFlip()
    {
        if (horizontalInput > 0 && !facingRight)
        {
            return true;
        }
        else if (horizontalInput < 0 && facingRight)
        {
            return true;
        }
        return false;
    }

    private void Flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;

        facingRight = !facingRight;
    }

    private void UpdateGroundedFalling()
    {
        playerSO.isGrounded = IsGrounded();
        playerSO.isFalling = IsFalling();
    }

    private bool IsGrounded()
    {
        if (boxCollider2D == null) return false;
        const float distance = 0.25f;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, direction, distance, groundLayer);
        bool isGrounded = hit.collider != null;
        return isGrounded;
    }

    private bool IsFalling()
    {
        return body.velocity.y < 0 && !playerSO.isGrounded;
    }

    private void UpdateGravity()
    {
        if (!playerSO.isGrounded)
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
}
