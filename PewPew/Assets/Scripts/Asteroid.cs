using System;
using UnityEngine;

[CreateAssetMenu(fileName = "asteroid", menuName = "Asteroid")]
public class Asteroid : ScriptableObject
{
    [SerializeField] private float size = 1;
    [SerializeField] private float speed = 1;
    [SerializeField] private float maxHp = 100;
    private float _hp;

    public float Size => size;
    public float Speed => speed;

    public float Hp
    {
        get => _hp;
        set => _hp = value;
    }

    private void OnEnable()
    {
        _hp = maxHp;
    }
}