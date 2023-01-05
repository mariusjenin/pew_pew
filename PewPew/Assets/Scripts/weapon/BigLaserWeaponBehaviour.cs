using projectile;
using UnityEngine;

namespace weapon
{
    public class BigLaserWeaponBehaviour : WeaponBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private float speedExpand;
        [SerializeField] private float speedShrink;

        protected override void Shoot()
        {
            GameObject instance = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            projectileBehavior = instance.GetComponent<BigLaserBehaviour>();

            projectileBehavior.Damage = damage;
            projectileBehavior.Range = range;
            ((BigLaserBehaviour) projectileBehavior).SpeedExpand = speedExpand;
            ((BigLaserBehaviour) projectileBehavior).SpeedShrink = speedShrink;
            projectileBehavior.DirectionTransform = transform;
            projectileBehavior.SpawnTransform = projectileSpawn;
        }
    }
}