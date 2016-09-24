using UnityEngine;
using System.Collections;

namespace YCG
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        int _maxEnemyCount = 10;
        [SerializeField]
        float _spawnInterval = 5f;
        [SerializeField]
        Vector2 _spawnRect = new Vector2(30, 30);

        float _elapsedTime;
        private EnemyUnitBase[] _enemys;

        public void LoadEnemy()
        {
            _enemys = Resources.LoadAll<EnemyUnitBase>("Prefabs/Enemy");
        }

        public void OnUpdate()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _spawnInterval)
            {
                Vector3 pos = new Vector3(Random.Range(-_spawnRect.x, _spawnRect.x), 0f, Random.Range(-_spawnRect.y, _spawnRect.y));
                var enemy = Instantiate(_enemys[Random.Range(0, _enemys.Length)], pos, Quaternion.identity) as IEnemyUnit;
                EnemyManager.instance.OnSpawnEnemy(enemy);
                _elapsedTime = 0f;
            }
        }
    }
}
