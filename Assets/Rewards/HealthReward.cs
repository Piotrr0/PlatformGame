using UnityEngine;
using health;
using prefab.interp;
using UnityEngine.Events;

namespace reward.health
{
    [RequireComponent(typeof(ObjectInterpolator))]
    public class HealthReward : MonoBehaviour, IReward
    {
        [SerializeField] private Health health;
        [SerializeField] private float bonusHealth;
        [SerializeField] private UnityEvent onHealthRewardCollect;

        public void CollectReward()
        {
            if (health != null)
            {
                health.MaxHealth += bonusHealth;
                health.Heal();
                onHealthRewardCollect?.Invoke();
            }
        }
    }
}
