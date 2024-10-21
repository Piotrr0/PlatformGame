using UnityEngine;
using player.combat;

namespace player.movement.jump
{
    public class PlayerJump : MonoBehaviour
    {
        private Rigidbody2D body;
        private PlayerMovement movement;
        private PlayerCombat comabat; // player jump should not be dependent on combat components

        private float jumpForce = 8f;
        private float jumpCutMultiplier = 0.3f;

        private float jumpBufferTime = 0.2f;
        private float jumpBufferCounter = 0f;

        private float coyoteTime = 0.1f;
        private float coyoteCounter = 0f;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            movement = GetComponent<PlayerMovement>();
            comabat = GetComponent<PlayerCombat>();
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
            if (comabat.isAttacking) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpBufferCounter = jumpBufferTime;

                if (movement.isGrounded || coyoteCounter > 0)
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
            if (movement.isGrounded && jumpBufferCounter > 0)
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
            if (!movement.isGrounded)
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
            if (Input.GetKeyUp(KeyCode.Space) && body && body.velocity.y > 0)
            {
                body.velocity = new Vector2(body.velocity.x, body.velocity.y * jumpCutMultiplier);
            }
        }
    }
}
