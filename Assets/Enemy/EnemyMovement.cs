using ai.controller;
using UnityEngine;

namespace enemy.movement
{
    public class EnemyMovement : AIController
    {
        [SerializeField] protected float speed;

        protected virtual bool canMove
        {
            get { return detectPlayer; }
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();
            if (canMove)
            {
                Move(player.position, speed);
            }
        }

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
    }
}