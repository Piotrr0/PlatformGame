using System.Collections;
using UnityEngine;

namespace prefab.interp
{
    public class ObjectInterpolator : MonoBehaviour
    {
        [SerializeField] private Vector2 startPosition;
        [SerializeField] private Vector2 endPosition;
        [SerializeField] private float duration;
        [SerializeField] private GameObject objectToInterpolate;

        public void StartInterpolate()
        {
            if (objectToInterpolate != null)
            {
                Vector2 globalStartPosition = transform.TransformPoint(startPosition);
                Vector2 globalEndPosition = transform.TransformPoint(endPosition);

                GameObject spawnedObject = Instantiate(objectToInterpolate, globalStartPosition, Quaternion.identity);
                StartCoroutine(InterpolateObject(globalStartPosition, globalEndPosition, duration, spawnedObject));
            }
        }

        private IEnumerator InterpolateObject(Vector2 globalStartPosition, Vector2 globalEndPosition, float duration, GameObject objectToInterpolate)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                objectToInterpolate.transform.position = Vector2.Lerp(globalStartPosition, globalEndPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            objectToInterpolate.transform.position = globalEndPosition;
            Destroy(objectToInterpolate, duration);
        }
    }
}
