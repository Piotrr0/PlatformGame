using UnityEngine;
using System.Collections;

namespace reward.coin
{
    public class CoinReward : MonoBehaviour, IReward
    {
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private int count;
        [SerializeField] private float collectibleDelay = 0.25f;

        [SerializeField] private Vector2 offsetX = new Vector2(-0.75f, 0.75f);
        [SerializeField] private Vector2 offsetY = new Vector2(0f, 0.75f);

        public void CollectReward()
        {
            CoinExplosion();
        }

        private void CoinExplosion()
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 offset = new Vector2(Random.Range(offsetX.x ,offsetX.y), Random.Range(offsetY.x, offsetY.y));
                Vector2 position = (Vector2)transform.position + offset;
                GameObject coin = Instantiate(coinPrefab, position, Quaternion.identity);

                CircleCollider2D coinCollider = coin.transform.GetComponent<CircleCollider2D>();
                if (coinCollider != null)
                {
                    coinCollider.enabled = false;
                    StartCoroutine(EnableCollider(coinCollider));
                }
            }
        }

        private IEnumerator EnableCollider(CircleCollider2D collider)
        {
            if(collider)
            {
                yield return new WaitForSeconds(collectibleDelay);
                collider.enabled = true;
            }
        }
    }
}
