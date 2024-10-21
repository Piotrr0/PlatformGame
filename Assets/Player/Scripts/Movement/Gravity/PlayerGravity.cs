using UnityEngine;

namespace player.movement.gravity
{
    public class PlayerGravity : MonoBehaviour
    {
        private Rigidbody2D body;
        private PlayerMovement movement;

        private float gravity = 1f;
        private float maxGravity = 5f;
        private float gravityIncrement = 2f;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            UpdateGravity();
        }

        private void UpdateGravity()
        {
            if (movement && !movement.isGrounded)
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
}