using UnityEngine;
using animations.strings;

namespace player.movement.jump
{
    public class PlayerJump : MonoBehaviour
    {
        private Rigidbody2D body;
        private Animator animator;

        [SerializeField] private float jumpForce = 8f;
        [SerializeField] private float jumpCutMultiplier = 0.3f;

        [SerializeField] private float jumpBufferTime = 0.2f;
        private float jumpBufferCounter = 0f;

        [SerializeField] private float coyoteTime = 0.1f;
        private float coyoteCounter = 0f;

        [SerializeField] private bool canDoubleJump;
        private int maxJumpCount = 1;
        private int jumpCount = 0;

        private bool isGrounded { get { return animator.GetBool(PlayerAnimationStrings.isGrounded); } }

        private bool canJump
        {
            get
            {
                return
                    animator.GetBool(PlayerAnimationStrings.canMove) &&
                    (isGrounded || (canDoubleJump && jumpCount < maxJumpCount)) &&
                    (coyoteCounter > 0 || jumpCount < maxJumpCount);
            }
        }


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
        }

        private void JumpButton()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpBufferCounter = jumpBufferTime;

                if (canJump)
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
                jumpCount++;
            }
        }

        private void HandleJumpBuffer()
        {
            if (isGrounded && jumpBufferCounter > 0 && canJump)
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
            if (isGrounded)
            {
                coyoteCounter = coyoteTime;
                jumpCount = 0;
            }
            else
            {
                coyoteCounter -= Time.deltaTime;
            }
        }

        private void JumpCutting()
        {
            if (Input.GetKeyUp(KeyCode.Space) && body && body.velocity.y > 0)
            {
                body.velocity = new Vector2(body.velocity.x, body.velocity.y * jumpCutMultiplier);
            }
        }

        public void OnBottleRewardCollect()
        {
            if (!canDoubleJump)
            {
                canDoubleJump = true;
                maxJumpCount = 2;
            }
        }
    }
}
