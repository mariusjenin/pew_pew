using System;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "enemy", menuName = "Enemy")]
    public class Enemy : ScriptableObject
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
}