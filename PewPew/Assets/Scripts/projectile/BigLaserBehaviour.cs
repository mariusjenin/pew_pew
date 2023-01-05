using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace projectile
{
    public class BigLaserBehaviour : ProjectileBehaviour
    {

        private float _speedExpand;
        private float _speedShrink;
        private float _targetScale;
        private bool _expanding;
        private Vector3 _positionSpawn;

        public float SpeedExpand
        {
            get => _speedExpand;
            set => _speedExpand = value;
        }
        
        public float SpeedShrink
        {
            get => _speedShrink;
            set => _speedShrink = value;
        }
        
        protected override void Start()
        {
            base.Start();
            _targetScale = range;
            _expanding = true;
            _positionSpawn = spawnTransform.position;
        }

        [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
        protected override void FixedUpdate()
        {
            float t = (Time.time - startTime) * _speedExpand;
            var localScale = transform.localScale;
            if (_expanding)
            {
                var scaleZ = localScale.z + _speedExpand * t;
                transform.localScale = new Vector3(localScale.x, localScale.y, scaleZ);

                if (scaleZ >= _targetScale)
                {
                    _expanding = false;
                    transform.position = _positionSpawn + transform.forward * _targetScale;
                }
                else transform.position = _positionSpawn + transform.forward * scaleZ;
            }
            else
            {
                var scaleZ = localScale.z - _speedShrink * t;
                transform.localScale = new Vector3(localScale.x, localScale.y, scaleZ);
                transform.position = _positionSpawn + transform.forward * (_targetScale + (_targetScale-scaleZ));
            
                if (scaleZ <= 0) Destroy(gameObject);
            }
        }

        protected override void HitAsteroid(Asteroid asteroid)
        {
            asteroid.TakeDamages(damage);
        }
    }
}