using ai.controller;
using UnityEngine.Events;
using UnityEngine;
using animations.strings;

namespace enemy.combat
{
    public class EnemyCombat : AIController
    {
        [SerializeField] protected UnityEvent onAttack;
        [SerializeField] protected float attackRange;

        protected Animator animator;

        protected virtual bool canAttack
        {
            get
            {
                return distanceToPlayer < attackRange;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            base.Update();
            if (canAttack)
            {
                Attack();
            }
        }

        public override void Attack()
        {
            base.Attack();
            animator.SetTrigger(ActorAnimationStrings.attackTrigger);
            onAttack.Invoke();
        }
    }
}