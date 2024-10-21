using UnityEngine;

namespace sprite.flip
{
    public class SpriteFlipper : MonoBehaviour
    {
        [SerializeField] private bool isFacingRight = true;

        private float moveDirection;
        public float MoveDirection { set {  moveDirection = value; } }

        private void Update()
        {
            if (CheckFlip(moveDirection))
            {
                Flip();
            }
        }

        private bool CheckFlip(float moveDirection)
        {
            if (moveDirection > 0 && !isFacingRight)
            {
                return true;
            }
            else if (moveDirection < 0 && isFacingRight)
            {
                return true;
            }
            return false;
        }

        private void Flip()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            isFacingRight = !isFacingRight;
        }
    }
}