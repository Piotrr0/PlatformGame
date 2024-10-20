using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider2D;
    private float distanceToPlayer = float.MaxValue;
    private float radius = 3f;
    private bool playerDetected = false;

    private float movementDirection = -1f;
    private bool facingRight = false;

    public bool PlayerDetected { get { return playerDetected; } }
    public float DistanceToPlayer { get { return distanceToPlayer; } }
    public Transform Player { get { return player; } }  

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(player != null)
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.position);
            DetectPlayer();
        }
        if (CheckFlip())
        {
            Flip();
        }
    }

    private void DetectPlayer()
    {
        if(distanceToPlayer <= radius)
        {
            playerDetected = true;
        }
    }

    public bool Move(Vector2 target, float speed)
    {
        movementDirection = Mathf.Sign(target.x - transform.position.x);

        if (IsGroundAhead(movementDirection))
        {
            float fixedY = transform.position.y;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, fixedY), target, speed * Time.deltaTime);
            return true;
        }
        return false;
    }

    private bool IsGroundAhead(float direction)
    {
        if (boxCollider2D != null)
        {
            Bounds colliderBounds = boxCollider2D.bounds;
            Vector2 rayStart = new Vector2(colliderBounds.center.x + (direction * colliderBounds.extents.x), colliderBounds.min.y);
            RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, 0.1f, groundLayer);

            return hit.collider != null;
        }
        return false;
    }

    private bool CheckFlip()
    {
        if (movementDirection > 0 && !facingRight)
        {
            return true;
        }
        else if (movementDirection < 0 && facingRight)
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
