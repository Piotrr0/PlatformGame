using UnityEngine;

namespace player.controller
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D body;
        private Animator animator;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        public void onHit(float damage, Vector2 knockback)
        {
            if (body != null)
            {
                body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
            }
        }

        public void onAttack()
        {
            if (body != null)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }
        }
    }
}
