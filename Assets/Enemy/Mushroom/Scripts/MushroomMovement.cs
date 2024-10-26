using enemy.mushroom.ai;
using ai.components.patrol;
using sprite.flip;

namespace enemy.mushroom.movement
{
    public class MushroomMovement : MushroomAI
    {
        private PatrolComponent patrolComponent;
        private SpriteFlipper flipper;

        private float speed = 3f;

        protected override void Awake()
        {
            base.Awake();
            patrolComponent = GetComponent<PatrolComponent>();
            flipper = GetComponent<SpriteFlipper>();
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
            if (PlayerDetected)
            {
                Move(player.position, speed);
            }
        }
    }
}

