using UnityEngine;

namespace projectile
{
    public abstract class ProjectileBehaviour : MonoBehaviour
    {
        protected float damage;
        protected float range;

        protected Transform spawnTransform;
        protected Transform directionTransform; //Forward dir of cannon

        protected float startTime;

        public float Damage
        {
            get => damage;
            set => damage = value;
        }

        public float Range
        {
            get => range;
            set => range = value;
        }

        public Transform DirectionTransform
        {
            get => directionTransform;
            set => directionTransform = value;
        }

        public Transform SpawnTransform
        {
            get => spawnTransform;
            set => spawnTransform = value;
        }

        protected virtual void Start()
        {
            startTime = Time.time;
        }

        protected abstract void FixedUpdate();

        protected virtual void HitAsteroid(Asteroid asteroid)
        {
            //Nothing
        }
        
        protected virtual void HitStayAsteroid(Asteroid asteroid)
        {
            //Nothing
        }

        private void OnTriggerStay(Collider other) 
        {
            if(other.CompareTag("asteroid"))
            {
                GameObject asteroidGo = other.gameObject;
                HitStayAsteroid(asteroidGo.GetComponent<Asteroid>());
            }
        }
        
        private void OnTriggerEnter(Collider other) 
        {
            if(other.CompareTag("asteroid"))
            {
                GameObject asteroidGo = other.gameObject;
                HitAsteroid(asteroidGo.GetComponent<Asteroid>());
            }
        }
    }
}