using ai.controller;
using UnityEngine.Events;
using UnityEngine;
using enemy.mushroom.animations.strings;

public class EnemyCombat : AIController
{
    [SerializeField] protected UnityEvent onAttack;
    [SerializeField] private UnityEvent onEndAttack;

    private Animator animator;
    [SerializeField] private float attackRange;

    private bool _isAttacking;
    public bool isAttacking
    {
        get => _isAttacking;
        private set
        {
            _isAttacking = value;
            if (animator != null)
                animator.SetBool(MushroomAnimationStrings.isAttacking, value);
        }
    }

    private bool canAttack
    {
        get
        {
            return !animator.GetCurrentAnimatorStateInfo(0).IsName(MushroomAnimationStrings.hit) &&
                !isAttacking &&
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

    protected virtual void FinishAttack()
    {
        isAttacking = false;
        onEndAttack.Invoke();
    }
}
