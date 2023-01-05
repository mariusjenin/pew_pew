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
            localScale = new Vector3(localScale.x,localScale.y,range*2);
            transform.localScale = localScale;
            transform.rotation = directionTransform.rotation;
            transform.position = directionTransform.position + transform.forward * range *2;
        }
        
        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
        protected override void FixedUpdate()
        {
            transform.rotation = directionTransform.rotation;
            transform.position = directionTransform.position + transform.forward * range*2;
        }

        protected override void HitStayAsteroid(Asteroid asteroid)
        {
            asteroid.TakeDamages(damage);
        }
    }
}