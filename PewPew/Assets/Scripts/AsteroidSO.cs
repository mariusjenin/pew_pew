using System;
using UnityEngine;

[CreateAssetMenu(fileName = "asteroid", menuName = "Asteroid")]

// ReSharper disable once InconsistentNaming
public class AsteroidSO : ScriptableObject
{
    [SerializeField] private float size = 1;
    [SerializeField] private float speed = 1;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private GameObject prefab;

    public float Size => size;
    public float Speed => speed;
    public GameObject Prefab => prefab;

    public float MaxHp => maxHp;
}