using projectile;
using UnityEngine;

namespace weapon
{
    public class LaserWeaponBehaviour : WeaponBehaviour
    {
        [SerializeField] private GameObject projectile;
        private GameObject _instanceProjectile;

        protected override void Shoot()
        {
            //Nothing
        }

        protected override void StartShooting()
        {
            base.StartShooting();
        
            _instanceProjectile = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            projectileBehavior = _instanceProjectile.GetComponent<LaserBehaviour>();

            projectileBehavior.Damage = damage;
            projectileBehavior.Range = range;
            projectileBehavior.DirectionTransform = transform;
            projectileBehavior.SpawnTransform = projectileSpawn;
        }

        protected override void EndShooting()
        {
            base.EndShooting();
            Destroy(_instanceProjectile);
        }
    }
}
