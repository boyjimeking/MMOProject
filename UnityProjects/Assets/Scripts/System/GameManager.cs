using UnityEngine;
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

        //For Debug
        public void ChangeNextCharacter()
        {
            int count = System.Enum.GetValues(typeof(Google2u.Player.rowIds)).Length;
            var id = (Google2u.Player.rowIds)Mathf.Repeat((int) PlayerManager.ID + 1, count);
            PlayerManager.SpawnMyControlUnit(id, PlayerManager.MyControlUnit.transform.position);
        }
    }
}
    
