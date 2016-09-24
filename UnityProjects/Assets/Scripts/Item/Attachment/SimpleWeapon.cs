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
            var bullet = BulletManager.instance.GetStraightBullet(transform.position);
            if (_owner is IPlayerUnit)
            {
                var player = _owner as IPlayerUnit;
                var target = TapTargetManager.instance.TargetEnemy;
                if (target != null)
                {
                    bullet.SetBulletInfo((target.Trans.position - transform.position).normalized, Range);
                }
                else
                {
                    bullet.SetBulletInfo( player.MoveDir, Range );
                }
            }
            else
            {
                bullet.SetBulletInfo( Vector3.ProjectOnPlane(transform.up, Vector3.up).normalized, Range );
            }
            bullet.Owner = _owner;
		}
	}
}
