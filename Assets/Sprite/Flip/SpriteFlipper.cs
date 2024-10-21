using UnityEngine;

namespace sprite.flip
{
    public class SpriteFlipper : MonoBehaviour
    {
        [SerializeField] private bool isFacingRight = true;
        private const float flipThreshold = 0.001f;
        private Vector3 lastPosition;


        private void Update()
        {
            float deltaX = transform.position.x - lastPosition.x;

            if (Mathf.Abs(deltaX) > flipThreshold)
            {
                float movementDirection = Mathf.Sign(deltaX);
                if (CheckFlip(movementDirection))
                {
                    Flip(); 
                }
            }

            lastPosition = transform.position;
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