using UnityEngine;

namespace projectile
{
    public class BaseProjectileBehaviour : ProjectileBehaviour
    {

        private float speed;
        private Vector3 _targetPos;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        
        protected override void Start()
        {
            base.Start();
            _targetPos = spawnTransform.position + (directionTransform.forward * range);
        }

        protected override void FixedUpdate()
        {
            if(transform.position == _targetPos)
            {
                Destroy(gameObject);
            }
            else
            {
                float timeElapsed = (Time.time - startTime) * speed * 5;

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
