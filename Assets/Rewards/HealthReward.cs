using UnityEngine;
using health;

namespace reward.health
{
    public class HealthReward : MonoBehaviour, IReward
    {
        [SerializeField] private Health health;
        [SerializeField] private float bonusHealth;

        public void CollectReward()
        {
            health.MaxHealth += bonusHealth;
            health.Heal();
        }
    }
}
