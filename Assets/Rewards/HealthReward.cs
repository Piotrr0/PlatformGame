using UnityEngine;
using health;
using prefab.interp;

namespace reward.health
{
    [RequireComponent(typeof(ObjectInterpolator))]
    public class HealthReward : MonoBehaviour, IReward
    {
        [SerializeField] private Health health;
        [SerializeField] private GameObject maxHealthIcon;
        [SerializeField] private float bonusHealth;

        private ObjectInterpolator interpolator;
        private Vector2 interpHeight = new Vector2(0f, 1f);

        private void Awake()
        {
            interpolator = GetComponent<ObjectInterpolator>();
        }

        public void CollectReward()
        {
            if (health != null && maxHealthIcon != null)
            {
                health.MaxHealth += bonusHealth;
                health.Heal();
                InterpIcon();
            }
        }

        private void InterpIcon()
        {
            if(interpolator != null)
            {
                Vector2 startPosition = transform.position;
                Vector2 endPosition = startPosition + interpHeight;

                GameObject icon = Instantiate(maxHealthIcon, startPosition, Quaternion.identity);
                StartCoroutine(interpolator.InterpolateObject(startPosition, endPosition, 0.5f, icon));
            }
        }
    }
}
