using UnityEngine;
using System.Collections;

namespace YCG
{
	public class SimpleEnemy : EnemyUnitBase
	{
        [SerializeField]
        int _hp = 20;
        [SerializeField]
        float _attack = 1.2f;
        [SerializeField]
        float _speed = 5f;
        [SerializeField]
        float _size = 2f;

        protected override void OnAwake()
        {
            base.OnAwake();
            HP = _hp;
            Attack = _attack;
            Speed = _speed;
            Size = _size;
        }
    }
}