using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    private AsteroidSO _asteroidSo;
    private Transform _target;
    private Vector3 _rotations;
    private float _hp;
    private const float RotationSpeedBase = 45f;
    private const float SpeedBase = 10f;

    public AsteroidSO AsteroidSo
    {
        get => _asteroidSo;
        set => _asteroidSo = value;
    }

    public Vector3 Rotations
    {
        get => _rotations;
    }

    public Transform Target
    {
        set => _target = value;
    }

    public void Init()
    {
        _hp = _asteroidSo.MaxHp;
        var tsh = RotationSpeedBase * _asteroidSo.Speed / _asteroidSo.Size;
        _rotations = new Vector3(
            Random.Range(-tsh,tsh),
            Random.Range(-tsh,tsh),
            Random.Range(-tsh,tsh));
    }

    public bool IsDead()
    {
        return _hp <= 0;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, SpeedBase * _asteroidSo.Speed * Time.deltaTime);
        transform.Rotate(_rotations * Time.deltaTime);
    }

    public void TakeDamages(float damage)
    {
        _hp -= damage;

        if(IsDead())
            Destroy(gameObject);
    }
    
}