using enemy.movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ai.components.patrol
{
    [RequireComponent(typeof(EnemyMovement))]
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private List<Vector2> patrolPoints;
        private int currentPatrolIndex = 0;

        private IEnumerator MoveToPatrolPoint(Vector2 localPatrolPoint, float speed)
        {
            Vector2 globalPatrolPoint = transform.TransformPoint(localPatrolPoint);

            while (Mathf.Abs(transform.position.x - globalPatrolPoint.x) > 0.01f)
            {
                Vector2 targetPosition = new Vector2(globalPatrolPoint.x, transform.position.y);
                if (!movement.Move(targetPosition, speed))
                {
                    yield break;
                }
                yield return null;
            }
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }

        public IEnumerator StartPatrolling(float speed)
        {
            if (patrolPoints == null || patrolPoints.Count == 0)
            {
                yield break;
            }

            while (movement)
            {
                yield return StartCoroutine(MoveToPatrolPoint(patrolPoints[currentPatrolIndex], speed));
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            foreach (Vector2 localPatrolPoint in patrolPoints)
            {
                Vector2 globalPatrolPoint = transform.TransformPoint(localPatrolPoint);
                Gizmos.DrawWireSphere(globalPatrolPoint, 0.25f);
            }
        }
    }
}
