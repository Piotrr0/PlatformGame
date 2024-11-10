using ai.components.patrol;
using sprite.flip;
using UnityEngine;
using enemy.movement;
using animations.strings;

namespace enemy.mushroom.movement
{
    public class MushroomMovement : EnemyMovement
    {
        private PatrolComponent patrolComponent;
        private SpriteFlipper flipper;
        private Animator animator;

        protected override bool canMove
        { 
            get 
            {
                return base.canMove && animator.GetBool(MushroomAnimationStrings.canMove); 
            } 
        }

        protected override void Awake()
        {
            base.Awake();
            patrolComponent = GetComponent<PatrolComponent>();
            flipper = GetComponent<SpriteFlipper>();
            animator = GetComponent<Animator>();
        }

        protected override void Start()
        {
            base.Start();
            StartCoroutine(patrolComponent.StartPatrolling(speed));
        }

        protected override void Update()
        {
            if (flipper != null)
            {
                flipper.MoveDirection = movementDirection;
            }
            if (canMove)
            {
                Move(player.position, speed);
                patrolComponent.StopAllCoroutines();
            }
        }

        public override bool Move(Vector2 target, float speed)
        {
            return base.Move(target, speed);
        }
    }
}