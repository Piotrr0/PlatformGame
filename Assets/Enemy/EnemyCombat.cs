using ai.controller;
using UnityEngine.Events;
using UnityEngine;
using animations.strings;

public class EnemyCombat : AIController
{
    [SerializeField] protected UnityEvent onAttack;

    private Animator animator;
    [SerializeField] private float attackRange;

    public bool isAttacking
    {
        get => animator.GetBool(ActorAnimationStrings.isAttacking);
        private set
        {
            if (animator != null)
                animator.SetBool(ActorAnimationStrings.isAttacking, value);
        }
    }

    private bool canAttack
    {
        get
        {
            return !isAttacking &&
                !animator.GetBool(ActorAnimationStrings.isHit) &&
                distanceToPlayer < attackRange;
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
        isAttacking = true;
        onAttack.Invoke();
    }
}
