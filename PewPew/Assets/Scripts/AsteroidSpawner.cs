using System;
using Unity.Profiling;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float lengthSpawn;
    [SerializeField] private float coneAngle;
    [SerializeField] private float verticalAngle;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform spaceshipTransform;
    private Quaternion _rotation;
    private Vector3 _origin;
    
    private void Start()
    {
        _rotation = cameraTransform.rotation;
        _origin = spaceshipTransform.position;
    }

    private void Update()
    {
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var dir = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.back) * Quaternion.AngleAxis(90 - coneAngle, Vector3.up) * Vector3.left;
        return _origin + _rotation * dir * lengthSpawn;
    }
    
    private void OnDrawGizmos()
    {
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
    }
}