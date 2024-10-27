using UnityEngine;
using sprite.flip;
using player.animations.strings;

namespace player.movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;

        private Rigidbody2D body;
        private BoxCollider2D boxCollider2D;
        private Animator animator;
        private SpriteFlipper flipper;

        private bool _isGrounded;
        public bool isGrounded
        {
            get => _isGrounded;
            private set
            {
                _isGrounded = value;
                if (animator != null)
                    animator.SetBool(PlayerAnimationStrings.IsGrounded, value);
            }
        }

        private bool _isFalling;
        public bool isFalling
        {
            get => _isFalling;
            private set
            {
                _isFalling = value;
                if (animator != null)
                    animator.SetBool(PlayerAnimationStrings.isFalling, value);
            }
        }

        private Vector2 _currentVelocity;
        public Vector2 currentVelocity
        {
            get => _currentVelocity;
            private set
            {
                _currentVelocity = value;
                if (animator != null)
                {
                    animator.SetFloat(PlayerAnimationStrings.xVelocity, value.x);
                    animator.SetFloat(PlayerAnimationStrings.yVelocity, value.y);
                }
            }
        }


        private bool canMove
        {
            get
            {
                return !animator.GetBool(PlayerAnimationStrings.isAttacking);
            }
        }


        private float moveSpeed = 7f;
        private float horizontalInput;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
            flipper = GetComponent<SpriteFlipper>();
        }

        private void Update()
        {
            if (flipper != null && canMove)
                flipper.MoveDirection = horizontalInput;

            UpdateGroundedFalling();
            ProcessMovementInput();
        }

        private void FixedUpdate()
        {
            if (canMove)
            {
                Move();
            }
        }

        private void Move()
        {
            if (body != null)
            {
                Vector2 velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);
                currentVelocity = velocity;
                body.velocity = currentVelocity;
            }
        }

        private void ProcessMovementInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        private void UpdateGroundedFalling()
        {
            isGrounded = IsGrounded();
            isFalling = IsFalling();
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
            return body.velocity.y < 0 && isGrounded;
        }
    }

}