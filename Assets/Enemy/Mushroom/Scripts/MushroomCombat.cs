using animations.strings;
using enemy.combat;
using UnityEngine;

public class MushroomCombat : EnemyCombat
{
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    protected override bool canAttack 
    {
        get { return base.canAttack && animator.GetBool(MushroomAnimationStrings.canMove); }
    }

    protected override void Attack()
    {
        base.Attack();
        animator.SetTrigger(MushroomAnimationStrings.attackTrigger);
    }
}
