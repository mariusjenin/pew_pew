using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Profiling;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [Serializable]
    public class SpawnAsteroid
    {
        [SerializeField] public float deltaT;
        [SerializeField] public AsteroidSO asteroidSo;
        private float _currentT;
        
        public float CurrentT
        {
            get => _currentT;
            set => _currentT = value;
        }

    }
    
    [SerializeField] private float lengthSpawn;
    [SerializeField] private float coneAngle;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform spaceshipTransform;
    [SerializeField] private List<SpawnAsteroid> _asteroids;
    
    private Quaternion _rotation;
    private Vector3 _origin;
    
    private void Start()
    {
        _rotation = cameraTransform.rotation;
        _origin = spaceshipTransform.position;

        foreach (var spawnAsteroid in _asteroids)
            spawnAsteroid.CurrentT = spawnAsteroid.deltaT;
    }

    private void Update()
    {

        foreach (var spawnAsteroid in _asteroids)
        {
            if (spawnAsteroid.CurrentT < Time.deltaTime)
            {
                var asteroidGo = Instantiate(spawnAsteroid.asteroidSo.Prefab);
                var asteroid = asteroidGo.GetComponent<Asteroid>();
                asteroid.transform.position = GetRandomSpawnPosition();
                asteroid.Target = spaceshipTransform;
                asteroid.AsteroidSo = spawnAsteroid.asteroidSo;
                asteroid.Init();
                spawnAsteroid.CurrentT = spawnAsteroid.deltaT;
            }
            else
            {
                spawnAsteroid.CurrentT -= Time.deltaTime;
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var dir = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.back) * Quaternion.AngleAxis( 90 - Random.Range(0,coneAngle), Vector3.up) * Vector3.left;
        return _origin + _rotation * dir * lengthSpawn;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _rotation *  Vector3.forward * lengthSpawn);
        Gizmos.color = Color.yellow;
        Vector3 dir1 = Quaternion.AngleAxis(0, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir2 = Quaternion.AngleAxis(45, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir3 = Quaternion.AngleAxis(90, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir4 = Quaternion.AngleAxis(135, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir5 = Quaternion.AngleAxis(180, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir6 = Quaternion.AngleAxis(225, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir7 = Quaternion.AngleAxis(270, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Vector3 dir8 = Quaternion.AngleAxis(315, Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        Gizmos.DrawLine(_origin, _origin + _rotation * dir1 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir2 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir3 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir4 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir5 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir6 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir7 * lengthSpawn);
        Gizmos.DrawLine(_origin, _origin + _rotation * dir8 * lengthSpawn);
        Gizmos.color = Color.green;
        for (int i = 0; i < 10; i++)
        {
            Gizmos.DrawLine(_origin, GetRandomSpawnPosition());
        }
    }
}