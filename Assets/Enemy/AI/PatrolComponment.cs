using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolComponment : MonoBehaviour
{
    private EnemyAI enemyAI;
    [SerializeField] private List<Vector2> patrolPoints;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Start()
    {
        StartCoroutine(SelectPatrolPoints());
    }

    private IEnumerator MoveToPatrolPoint(Vector2 patrolPoint)
    {
        while (Mathf.Abs(transform.position.x - patrolPoint.x) > 0.01f) 
        {
            Vector2 targetPosition = new Vector2(patrolPoint.x, transform.position.y);
            if(enemyAI == null || !enemyAI.Move(targetPosition) || enemyAI.PlayerDetected)
            {
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator SelectPatrolPoints()
    {
        while (enemyAI && !enemyAI.PlayerDetected)
        {
            foreach (Vector2 patrolPoint in patrolPoints)
            {
                yield return StartCoroutine(MoveToPatrolPoint(patrolPoint));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(Vector2 patrolPoint in patrolPoints)
        {
            Gizmos.DrawWireSphere(patrolPoint, 0.25f);
        }
    }
}
