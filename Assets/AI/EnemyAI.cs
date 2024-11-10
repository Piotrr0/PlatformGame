using UnityEngine;

namespace ai.controller
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected LayerMask groundLayer;
        protected BoxCollider2D boxCollider2D;

        protected float radius = 3f;
        protected float movementDirection = -1f;

        private bool _detectPlayer = false;
        public bool detectPlayer
        {
            get
            {
                if (!_detectPlayer)
                {
                    _detectPlayer = DetectPlayer();
                }
                return _detectPlayer;
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

        protected virtual bool DetectPlayer()
        {
            if (Vector2.Distance(player.position,transform.position) <= radius)
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