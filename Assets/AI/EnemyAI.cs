using UnityEngine;
using UnityEngine.Events;

namespace ai.controller
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected LayerMask groundLayer;
        protected BoxCollider2D boxCollider2D;

        [SerializeField] protected float radius = 3f;

        protected float movementDirection = -1f;
        [SerializeField] protected UnityEvent onAttack;

        private bool _playerDetected = false;

        public bool PlayerDetected
        {
            get
            {
                if(_playerDetected)
                    return true;
                else
                {
                    _playerDetected = DetectPlayer();
                    return _playerDetected;
                }
                    
            }
        }

        public float MovementDirection { get { return movementDirection; } }
        public Transform Player { get { return player; } }

        protected virtual void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        protected virtual void Start() { }

        protected virtual void Update() { }

        public virtual bool Move(Vector2 target, float speed)
        {
            movementDirection = Mathf.Sign(target.x - transform.position.x);

            float fixedY = transform.position.y;
            target = new Vector2(target.x, fixedY);

            if (IsGroundAhead(movementDirection))
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, fixedY), target, speed * Time.deltaTime);
                return true;
            }
            return false;
        }

        public virtual void Attack()
        {
            onAttack?.Invoke();
        }

        protected virtual bool DetectPlayer()
        {
            if (Vector2.Distance(transform.position, player.position) <= radius)
            {
                return true;
            }
            return false;
        }

        protected virtual bool IsGroundAhead(float direction)
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
    }
}

