using System.Collections;
using UnityEngine;

namespace prefab.interp
{
    public class ObjectInterpolator : MonoBehaviour
    {
        public IEnumerator InterpolateObject(Vector2 startPosition, Vector2 endPosition, float duration ,GameObject interpedObejct)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                interpedObejct.transform.position = Vector2.Lerp(startPosition, endPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            interpedObejct.transform.position = endPosition;
            Destroy(interpedObejct, duration);
        }
    }
}