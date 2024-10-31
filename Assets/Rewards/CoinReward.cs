using UnityEngine;
using System.Collections;

namespace reward.coin
{
    public class CoinReward : MonoBehaviour, IReward
    {
        [SerializeField] private float count;
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private float collectibleDelay = 0.25f;

        public void CollectReward()
        {
            CoinExplosion();
        }

        private void CoinExplosion()
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 offset = new Vector2(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f));
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
