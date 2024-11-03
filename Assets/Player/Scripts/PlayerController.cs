using player.movement;
using UnityEngine;

namespace player.controller
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D body;
        [SerializeField] private int coins = 0;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        public void OnHit(float damage, Vector2 knockback)
        {
            if (body != null)
            {
                body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
            }
        }

        public void OnAttack()
        {
            if (body != null)
            {
                body.velocity = new Vector2(0, body.velocity.y);
            }
        }

        public void OnCoinCollet()
        {
            coins++;
        }
    }
}
