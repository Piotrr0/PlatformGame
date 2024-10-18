using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    private Rigidbody2D body;
    private Animator animator;

    private float jumpForce = 8f;
    private float jumpCutMultiplier = 0.3f;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter = 0f;

    private float coyoteTime = 0.1f;
    private float coyoteCounter = 0f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        JumpButton();
        HandleJumpBuffer();
        HandleCoyoteCounter();
        JumpCutting();

        animator.SetFloat("yVelocity", body.velocity.y);
    }

    private void JumpButton()
    {
        if (playerSO.combatState != CombatState.Unoccupied) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;

            if (playerSO.isGrounded || coyoteCounter > 0)
            {
                coyoteCounter = 0;
                Jump();
            }
        }
    }

    private void Jump()
    {
        if (body != null)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }

    private void HandleJumpBuffer()
    {
        if (playerSO.isGrounded && jumpBufferCounter > 0)
        {
            Jump();
            jumpBufferCounter = 0f;
        }

        if (jumpBufferCounter > 0)
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    private void HandleCoyoteCounter()
    {
        if (!playerSO.isGrounded)
        {
            coyoteCounter -= Time.deltaTime;
        }
        else
        {
            coyoteCounter = coyoteTime;
        }
    }

    private void JumpCutting()
    {
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * jumpCutMultiplier);
        }
    }
}
