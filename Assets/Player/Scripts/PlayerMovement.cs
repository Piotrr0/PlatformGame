using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    private Rigidbody2D body;
    private Animator animator;
    private float horizontalInput;
    private float moveSpeed = 7f;
    private bool facingRight = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessMovementInput();
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
}
