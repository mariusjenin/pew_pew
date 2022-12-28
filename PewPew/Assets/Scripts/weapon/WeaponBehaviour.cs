using projectile;
using UnityEngine;
using UnityEngine.InputSystem;

namespace weapon
{
    public abstract class WeaponBehaviour : MonoBehaviour
    {
        [SerializeField] private InputActionReference shootingReference = null;
        [SerializeField] private float cooldown;
        [SerializeField] protected Transform projectileSpawn;
        [SerializeField] protected float range;
        [SerializeField] protected float damage;
        protected ProjectileBehaviour projectileBehavior;
        protected bool onCoolDown;
        protected float lastShotTime;
        protected bool isShooting;

        protected virtual void StartShooting()
        {
            isShooting = true;
        }

        public virtual void EndShooting()
        {
            isShooting = false;
        }

        protected abstract void Shoot();

        protected bool PreShoot()
        {
            if (!onCoolDown)
            {
                lastShotTime = Time.time;
                return true;
            }
            return false;
        }

        private void CheckCooldown()
        {
            float elapsedTime = Time.time - lastShotTime;
            onCoolDown = !(cooldown <= elapsedTime);
      
        }
    
        void Start()
        {
            onCoolDown = false;
            isShooting = false;
        }

        void FixedUpdate()
        {
            CheckCooldown();
        
            float pressed = shootingReference.action.ReadValue<float>();

            if(pressed > 0)
            {
                if(!isShooting) StartShooting();
            }
            else
            {
                if(isShooting) EndShooting();
            }

            if (isShooting && PreShoot()) Shoot();
        }

    }
}
