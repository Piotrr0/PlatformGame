using attack;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace projectile
{
    public class Projectile : Attack
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float lifeTime = 2.5f;

        public void FireProjectile()
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        IEnumerator ProjectileLifetime()
        {
            yield return new WaitForSeconds(lifeTime);
            DestroyProjectile();
        }

        public void DestroyProjectile()
        {
            Destroy(gameObject);
        }

        protected override void Update()
        {
            base.Update();
            FireProjectile();
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            DestroyProjectile();
        }
    }
}
