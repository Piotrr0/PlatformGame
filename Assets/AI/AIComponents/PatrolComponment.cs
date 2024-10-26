using ai.controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ai.components.patrol
{
    [RequireComponent(typeof(AIController))]
    public class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private AIController aiController;
        [SerializeField] private List<Vector2> patrolPoints;
        private int currentPatrolIndex = 0;

        private IEnumerator MoveToPatrolPoint(Vector2 patrolPoint, float speed)
        {
            while (Mathf.Abs(transform.position.x - patrolPoint.x) > 0.01f)
            {
                Vector2 targetPosition = new Vector2(patrolPoint.x, transform.position.y);
                if (aiController == null || !aiController.Move(targetPosition, speed) || aiController.PlayerDetected)
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

            while (aiController)
            {
                if (!aiController.PlayerDetected)
                {
                    yield return StartCoroutine(MoveToPatrolPoint(patrolPoints[currentPatrolIndex], speed));
                }
                yield return null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            if (patrolPoints == null) return;
            foreach (Vector2 patrolPoint in patrolPoints)
            {
                Gizmos.DrawWireSphere(patrolPoint, 0.25f);
            }
        }
    }
}

