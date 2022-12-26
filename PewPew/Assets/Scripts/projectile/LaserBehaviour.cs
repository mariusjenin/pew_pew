using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace projectile
{
    public class LaserBehaviour : ProjectileBehaviour
    {
        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
        protected override void Start()
        {
            base.Start();
            var localScale = transform.localScale;
            localScale = new Vector3(localScale.x,localScale.y,range);
            transform.localScale = localScale;
            transform.rotation = directionTransform.rotation;
            transform.position = directionTransform.position + transform.forward * range;
        }
        
        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
        protected override void FixedUpdate()
        {
            transform.rotation = directionTransform.rotation;
            transform.position = directionTransform.position + transform.forward * range;
        }

        protected override void HitAsteroid(Asteroid asteroid)
        {
            asteroid.TakeDamages(damage);
        }
    }
}