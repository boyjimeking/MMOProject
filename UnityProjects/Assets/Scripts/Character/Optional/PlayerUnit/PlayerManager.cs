using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace YCG.Player
{
    public class PlayerManager
    {
        private static readonly string ResourcePath = "Prefabs/Player";

        List<PlayerUnitBase> _playerUnitList;
        public PlayerUnitBase MyControlUnit { get; private set; }

        public PlayerManager()
        {
            _playerUnitList = Resources.LoadAll<PlayerUnitBase>(ResourcePath).ToList();
            SpawnMyControlUnit(Google2u.Player.rowIds.chr0001, Vector3.zero);
        }

        public void SpawnMyControlUnit(Google2u.Player.rowIds id, Vector3 pos)
        {
            if (MyControlUnit != null)
            {
                GameObject.DestroyImmediate(MyControlUnit);
            }
            var spawnUnit = _playerUnitList[(int)id];
            MyControlUnit = GameObject.Instantiate(spawnUnit, pos, spawnUnit.transform.rotation) as PlayerUnitBase;
            MyControlUnit.SetController(ControlType.Self);
            GameManager.instance.CameraManager.SetTrackTarget(MyControlUnit.transform);
        }

        public enum ControlType
        {
            Self,
            Network,
            AI,
        }
    }
}