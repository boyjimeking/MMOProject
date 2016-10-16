using UnityEngine.SceneManagement;
using YCG.Player;

namespace YCG
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        public PlayerManager PlayerManager { get; private set; }
        public EnemyManager EnemyManager { get; private set; }
        public BulletManager BulletManager { get; private set; }
        public CameraManager CameraManager { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            CameraManager = GetComponentInChildren<CameraManager>();
            BulletManager = GetComponentInChildren<BulletManager>();
            PlayerManager = new PlayerManager();
            EnemyManager = new EnemyManager(GetComponentInChildren<EnemySpawner>());
        }

        void Update()
        {
            EnemyManager.Update();
        }

        public void OnPlayerDeath()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
    
