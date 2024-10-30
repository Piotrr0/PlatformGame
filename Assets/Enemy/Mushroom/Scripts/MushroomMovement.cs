using enemy.mushroom.ai;
using ai.components.patrol;
using sprite.flip;
using UnityEngine;
using animations.strings;

namespace enemy.mushroom.movement
{
    public class MushroomMovement : MushroomAI
    {
        private PatrolComponent patrolComponent;
        private SpriteFlipper flipper;
        private Animator animator;

        private float speed = 3f;

        private bool canMove
        {
            get { return animator.GetBool(ActorAnimationStrings.canMove); }
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
            base.Update();
            if (flipper != null)
            {
                flipper.MoveDirection = movementDirection;
            }
            if (PlayerDetected && canMove)
            {
                Move(player.position, speed);
            } 
        }
    }
}

