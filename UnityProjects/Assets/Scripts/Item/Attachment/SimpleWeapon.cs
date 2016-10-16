using UnityEngine;
using YCG.Player;

namespace YCG.Attachment
{
	public class SimpleWeapon : WeaponBase
	{
		BulletBase _bullet;

		protected override void OnAwake ()
		{
			base.OnAwake ();
			_invokeType = InvokeType.ConstInterval;
            Range = 10f;
            InvokeInterval = 0.25f;
		}

		public override void OnInvoke (AttachmentArgs args)
		{
			base.OnInvoke (args);
            var bullet = GameManager.instance.BulletManager.GetStraightBullet(transform.position);
            BulletParam param = new BulletParam()
            {
                Power = (int)(50 * _owner.Attack),
                Speed = 10f,
                Range = Range,
            };
            if (_owner is IPlayerUnit)
            {
                var player = _owner as IPlayerUnit;
                var target = TapTargetManager.instance.TargetEnemy;
                if (target != null)
                {
                    param.Direction = (target.Trans.position - transform.position).normalized;
                }
                else
                {
                    param.Direction = player.MoveDir;
                }
            }
            else
            {
                param.Direction = Vector3.ProjectOnPlane(transform.up, Vector3.up).normalized;
            }
            bullet.SetBulletInfo(param);
            bullet.Owner = _owner;
		}
	}
}
