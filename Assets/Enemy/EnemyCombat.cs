using ai.controller;
using UnityEngine.Events;
using UnityEngine;
using animations.strings;

public class EnemyCombat : AIController
{
    [SerializeField] protected UnityEvent onAttack;

    private Animator animator;
    [SerializeField] private float attackRange;

    private bool canAttack
    {
        get
        {
            return distanceToPlayer < attackRange &&
                animator.GetBool(ActorAnimationStrings.canMove);
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
