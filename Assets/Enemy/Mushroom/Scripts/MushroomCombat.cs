using animations.strings;
using enemy.combat;

public class MushroomCombat : EnemyCombat
{
    protected override bool canAttack 
    {
        get { return base.canAttack && animator.GetBool(MushroomAnimationStrings.canMove); }
    }

    public override void Attack()
    {
        base.Attack();
    }
}
