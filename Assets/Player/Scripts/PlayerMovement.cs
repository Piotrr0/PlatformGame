using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private bool isGrounded = false;
    private bool isFalling = false;

    private float horizontalInput;
    private float moveSpeed = 7f;
    private bool facingRight = true;

    private float gravity = 1f;
    private float maxGravity = 5f;
    private float gravityIncrement = 2f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        UpdateGroundedFalling();
        ProcessMovementInput();
        UpdateGravity();
        if (CheckFlip())
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(playerSO.combatState == CombatState.Unoccupied)
        {
            Move();
        }
    }

    private void Move()
    {
        if (body)
        {
            Vector2 velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);
            body.velocity = velocity;
            animator.SetFloat("xVelocity", Mathf.Abs(body.velocity.x));
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
        isGrounded = IsGrounded();
        isFalling = IsFalling();
        playerSO.isGrounded = isGrounded;
        playerSO.isFalling = isFalling;
        animator.SetBool("IsGrounded", isGrounded);
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
        return body.velocity.y < 0 && !isGrounded;
    }

    private void UpdateGravity()
    {
        if (isFalling)
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
