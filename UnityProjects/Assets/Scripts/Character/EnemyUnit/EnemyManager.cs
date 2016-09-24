using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace YCG
{
    public class EnemyManager : SingletonBehaviour<EnemyManager>
    {
        private List<IEnemyUnit> _enemyList = new List<IEnemyUnit>();
        private EnemySpawner _spawner;

        protected override void OnAwake()
        {
            base.OnAwake();
            _spawner = GetComponentInChildren<EnemySpawner>();
            _spawner.LoadEnemy();
        }

        void Update()
        {
            _spawner.OnUpdate();
        }

        #region Public Method
        public IEnemyUnit GetNearestEnemy(Vector3 pos)
        {
            if (_enemyList.Any() == false)
                return null;

            int index = 0;
            float min = Mathf.Infinity;
            for (int i = 0; i < _enemyList.Count; i++)
            {
                float sqrDist = (_enemyList[i].Trans.position - pos).sqrMagnitude;
                if (min > sqrDist)
                {
                    index = i;
                    min = sqrDist;
                }
            }
            return _enemyList[index];
        }

        #endregion

        #region Event
        public void OnSpawnEnemy(IEnemyUnit enemy)
        {
            _enemyList.Add(enemy);
        }

        public void OnDeathEnemy(IEnemyUnit enemy)
        {
            _enemyList.Remove(enemy);
        }
        #endregion
    }
}