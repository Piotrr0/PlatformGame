using UnityEngine;


[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public Animator animator;
    public bool isGrounded { get { return animator.GetBool("IsGrounded"); } set { animator.SetBool("IsGrounded", value); } }
    public bool isFalling { get { return animator.GetBool("isFalling"); } set { animator.SetBool("isFalling", value); } }
    public bool isAttacking { get { return animator.GetBool("isAttacking"); } set { animator.SetBool("isAttacking", value); } }
    public Vector2 currentVelocity
    { 
        get 
        {
            return new Vector2(animator.GetFloat("xVelocity"), animator.GetFloat("yVelocity"));
        }
        set
        {
            animator.SetFloat("xVelocity", value.x);
            animator.SetFloat("yVelocity", value.y);
        }
    }
}
