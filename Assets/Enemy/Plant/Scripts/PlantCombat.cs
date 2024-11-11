using animations.strings;
using enemy.combat;
using UnityEngine;

namespace enemy.plant.combat
{
    public class PlantCombat : EnemyCombat
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private bool isPlayerInRange = false;

        private Animator animator;

        protected override bool canAttack
        {
            get { return isPlayerInRange; }
        }

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Attack()
        {
            base.Attack();
            animator.SetTrigger(PlantAnimationStrings.attackTrigger);
        }

        private void FireProjectile()
        {
            if (projectile != null)
            {
                GameObject proj = Instantiate(projectile);
                proj.transform.position = transform.position;
            }
        }

        public void OnZoneEnter()
        {
            isPlayerInRange = true;
            if (animator != null)
            {
                animator.SetBool(PlantAnimationStrings.isActive, true);
            }
        }

        public void OnZoneExit()
        {
            isPlayerInRange = false;
            if (animator != null)
            {
                animator.SetBool(PlantAnimationStrings.isActive, false);
            }
        }
    }
}
