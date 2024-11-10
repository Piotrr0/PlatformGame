using animations.strings;
using enemy.combat;
using UnityEngine;

namespace enemy.plant.combat
{
    public class PlantCombat : EnemyCombat
    {
        [SerializeField] private GameObject projectile;

        private BoxCollider2D activateBox;
        [SerializeField] private bool isPlayerInRange = false;
        [SerializeField] private Animator animator;

        protected override bool canAttack
        {
            get { return isPlayerInRange; }
        }

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
            activateBox = GetComponent<BoxCollider2D>();
            activateBox.size = new Vector2(attackRange, 2);
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Attack()
        {
            base.Attack();
        }

        private void FireProjectile()
        {
            if (projectile != null)
            {
                GameObject proj = Instantiate(projectile);
                proj.transform.position = transform.position;
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                isPlayerInRange = true;
                animator.SetBool(PlantAnimationStrings.isActive, isPlayerInRange);
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                isPlayerInRange = false;
                animator.SetBool(PlantAnimationStrings.isActive, isPlayerInRange);
            }
        }
    }
}
