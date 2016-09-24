using UnityEngine;
using System.Collections;
using YCG.Attachment;

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

        float _elapsedTime = 0f;

        protected override void OnAwake()
        {
            base.OnAwake();
            HP = _hp;
            Attack = _attack;
            Speed = _speed;
            Size = _size;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > 2f)
            {
                for (int i = 0; i < 8; i++)
                {
                    var param = new BulletParam()
                    {
                        Power = 50,
                        Speed = 10f,
                        Range = 20f,
                        Direction = Quaternion.AngleAxis(i * 45, Vector3.up) * Vector3.forward
                    };
                    BulletManager.instance.ShotStraightBullet(param, this, transform.position);
                }
                _elapsedTime = 0f;
            }
        }
    }
}