using UnityEngine;

namespace camera.controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

        [SerializeField] private float lookaheadTime = 0.5f;
        [SerializeField] private float lookaheadSmoothing = 1f;
        [SerializeField] private float xDamping = 1f;
        [SerializeField] private float yDamping = 1f;
        [SerializeField] private float zDamping = 1f;

        private Vector3 lookaheadPosition;

        private void Update()
        {
            if (player != null)
            {
                PredictMovement(player);
                MoveCamera(player);
            }
        }

        private void MoveCamera(Transform target)
        {
            Vector3 targetPosition = target.position + offset + lookaheadPosition;
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, targetPosition.x, xDamping * Time.deltaTime),
                Mathf.Lerp(transform.position.y, targetPosition.y, yDamping * Time.deltaTime),
                Mathf.Lerp(transform.position.z, targetPosition.z, zDamping * Time.deltaTime)
            );
        }

        private void PredictMovement(Transform target)
        {
            Rigidbody2D body = target.GetComponent<Rigidbody2D>();
            if (body)
            {
                Vector2 velocity = body.velocity;
                Vector3 newLookaheadPosition = velocity * lookaheadTime;
                lookaheadPosition = Vector3.Lerp(lookaheadPosition, newLookaheadPosition, lookaheadSmoothing * Time.deltaTime);
                return;
            }
            lookaheadPosition = target.position;
        }

        private void OnDrawGizmos()
        {
            if (player != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(player.position, player.position + lookaheadPosition);
                Gizmos.DrawCube(player.position + lookaheadPosition, Vector3.one/4);
            }
        }
    }
}
