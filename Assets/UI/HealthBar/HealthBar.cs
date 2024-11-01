using player.health;
using UnityEngine;
using UnityEngine.UI;

namespace ui.healthBar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();            
        }

        // Called onHealthChanged
        public void UpdateHealthBar(float health)
        {
            float percent = health / playerHealth.MaxHealth;
            slider.value = percent;
        }
    }
}
