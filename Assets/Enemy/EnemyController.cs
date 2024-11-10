using UnityEngine;


namespace enemy.controller
{
    public class EnemyController : MonoBehaviour
    {
        protected bool _playerDetected = false;
        public bool playerDetected
        {
            get { return _playerDetected; }
            private set { _playerDetected = value; }
        }

        protected virtual void Awake() { }

        protected virtual void Update() { }

        public virtual void OnAttack() { }

        public virtual void OnHit(float damage, Vector2 knockback) { }
    }
}

