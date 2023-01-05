using UnityEngine;

namespace projectile
{
    public class BaseProjectileBehaviour : ProjectileBehaviour
    {

        private float _speed;
        private Vector3 _targetPos;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        
        protected override void Start()
        {
            base.Start();
            _targetPos = spawnTransform.position + directionTransform.forward * range;
        }

        protected override void FixedUpdate()
        {
            float dist = Vector3.Distance(transform.position, _targetPos);
            if(dist < 0.5)
            {
                Destroy(gameObject);
            }
            else
            {
                float timeElapsed = (Time.time - startTime) * _speed;

                float t = timeElapsed / _targetPos.magnitude;

                transform.position = Vector3.Lerp(spawnTransform.position, _targetPos, t);

            }

        }

        protected override void HitAsteroid(Asteroid asteroid)
        {
            asteroid.TakeDamages(damage);
            Destroy(gameObject);
        }
    }
}
