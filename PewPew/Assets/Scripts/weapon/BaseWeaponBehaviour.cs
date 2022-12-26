using projectile;
using UnityEngine;

namespace weapon
{
    public class BaseWeaponBehaviour : WeaponBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private float speed;

        protected override void Shoot()
        {
            GameObject instance = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            projectileBehavior = instance.GetComponent<BaseProjectileBehaviour>();

            projectileBehavior.Damage = damage;
            projectileBehavior.Range = range;
            ((BaseProjectileBehaviour) projectileBehavior).Speed = speed;
            projectileBehavior.DirectionTransform = transform;
            projectileBehavior.SpawnTransform = projectileSpawn;
        }
    }
}
