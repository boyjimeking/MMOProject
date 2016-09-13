using UnityEngine;
using System.Collections;
using YCG.Player;

namespace YCG
{
    public class SimpleOptionalUnit : OptionalUnitBase
    {
        [SerializeField]
        PlayerUnitBase _playerUnit;
        [SerializeField]
        float _maxDistance = 3f;
        [SerializeField]
        float _attackRange = 0.5f;
        [SerializeField]
        float _attackInterval = 0.5f;
        [SerializeField]
        int _hp = 20;
        [SerializeField]
        float _attack = 2f;
        [SerializeField]
        float _speed = 3f;
        [SerializeField]
        float _size = 2f;

        float _attackWaitTime = 0f;
        EnemyUnitBase _targetUnit;

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
            if (_targetUnit != null)
            {
                ChaseTarget();
            }
            
            Vector3 diff = transform.position - _playerUnit.transform.position;
            if (diff.sqrMagnitude > _maxDistance * _maxDistance)
            {
                transform.position = _playerUnit.transform.position + _maxDistance * diff.normalized;
            }

            //Reset
            _attackWaitTime -= Time.deltaTime;
            _targetUnit = TapTargetManager.instance.TargetEnemy;
        }

        private void ChaseTarget()
        {
            Vector3 targetDir = _targetUnit.transform.position - transform.position;
            Vector3 dir = targetDir.normalized;
            float sqrDist = targetDir.sqrMagnitude;
            if (sqrDist > _attackRange * _attackRange)
            {
                transform.position += Time.deltaTime * Speed * dir;
            }
            else
            {
                if (_attackWaitTime < 0)
                {
                    _attackWaitTime = _attackInterval;
                    _targetUnit.Damage((int)Attack);
                }
            }
        }

        void OnTriggerStay(Collider hitCol)
        {
            if (_targetUnit != null)
                return;

            var character = hitCol.GetComponent<ICharacterUnit>();
            if (character == null)
                return;

            if (character is EnemyUnitBase)
            {
                _targetUnit = character as EnemyUnitBase;
            }
        }
    }
}
