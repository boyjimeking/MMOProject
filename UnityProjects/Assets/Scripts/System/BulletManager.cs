using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using YCG.Attachment;

namespace YCG
{
    public class BulletManager : MonoBehaviour
    {
        List<IBullet> _bulletPool = new List<IBullet>();
        BulletBase _straightBullet;

        void Awake()
        {
            LoadBullet();
        }

        private void LoadBullet()
        {
            _straightBullet = Resources.Load<BulletBase>("Prefabs/Bullet/StraightBullet");
        }

        public IBullet GetStraightBullet(Vector3 position)
        {
            if (_bulletPool.Any())
            {
                var bullet = _bulletPool[0];
                _bulletPool.RemoveAt(0);
                bullet.Enabled = true;
                bullet.Trans.position = position;
                return bullet;
            }

            var newBullet = Instantiate(_straightBullet, position, _straightBullet.transform.rotation) as IBullet;
            newBullet.Trans.SetParent(this.transform);
            return newBullet;
        }

        public void ShotStraightBullet(BulletParam param, ICharacterUnit owner, Vector3 pos)
        {
            var bullet = GetStraightBullet(pos);
            bullet.SetBulletInfo(param);
            bullet.Owner = owner;
        }

        public void OnReleaseBullet(IBullet bullet)
        {
            bullet.Enabled = false;
            _bulletPool.Add(bullet);
        }
    }
}