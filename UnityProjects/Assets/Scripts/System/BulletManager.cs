using UnityEngine;
using System.Collections;
using YCG.Attachment;

namespace YCG
{
    public class BulletManager : SingletonBehaviour<BulletManager>
    {
        BulletBase _straightBullet;

        protected override void OnAwake()
        {
            base.OnAwake();
            LoadBullet();
        }

        private void LoadBullet()
        {
            _straightBullet = Resources.Load<BulletBase>("Prefabs/Bullet/StraightBullet");
        }

        public IBullet GetStraightBullet(Vector3 position)
        {
            return Instantiate(_straightBullet, position, _straightBullet.transform.rotation) as IBullet;
        }

        public void ShotStraightBullet(BulletParam param, ICharacterUnit owner, Vector3 pos)
        {
            var bullet = GetStraightBullet(pos);
            bullet.SetBulletInfo(param);
            bullet.Owner = owner;
        }
    }
}