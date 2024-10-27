using UnityEngine;
using enemy.controller;

namespace enemy.mushroom.controller
{
    public class MushroomController : EnemyController
    {
        private Rigidbody2D body;

        protected override void Awake()
        {
            base.Awake();
            body = GetComponent<Rigidbody2D>();
        }

        protected override void Update()
        {
            base.Awake();
        }

        public override void OnAttack()
        {
            base.OnAttack();
        }

        public override void OnHit(float damage, Vector2 knockback)
        {
            base.OnHit(damage, knockback);
            if (body != null)
            {
                body.velocity = new Vector2(knockback.x, body.velocity.y + knockback.y);
            }
        }
    }

}
