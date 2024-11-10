using ai.controller;
using UnityEngine.Events;
using UnityEngine;

namespace enemy.combat
{
    public class EnemyCombat : AIController
    {
        [SerializeField] protected UnityEvent onAttack;
        [SerializeField] protected float attackRange;

        protected virtual bool canAttack
        {
            get
            {
                return Vector2.Distance(player.position, transform.position) < attackRange;
            }
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();
            if (canAttack)
            {
                Attack();
            }
        }

        protected virtual void Attack()
        {
            onAttack.Invoke();
        }
    }
}
