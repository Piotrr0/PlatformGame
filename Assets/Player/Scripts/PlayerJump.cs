using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    private float jumpForce = 10f;
    private float jumpCutMultiplier = 0.3f;

    private float gravity = 1f;
    private float maxGravity = 5f;
    private float gravityIncrement = 2f;

    private bool isGrounded = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        animator.SetFloat("yVelocity", body.velocity.y);
        JumpButton();
        UpdateGravity();
        isGrounded = IsGrounded();
    }

    private void JumpButton()
    {
        if (playerSO.combatState != CombatState.Unoccupied) return;

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
        if (body != null && isGrounded)
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
        const float distance = 0.5f;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, direction, distance, groundLayer);
        bool isGrounded = hit.collider != null;
        animator.SetBool("IsGrounded", isGrounded);
        return isGrounded;
    }

    private bool isFalling()
    {
        return body.velocity.y < 0 && !isGrounded;
    }
}
