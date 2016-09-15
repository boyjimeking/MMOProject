using UnityEngine;
using YCG.Player;

namespace YCG.Attachment
{
	public class SimpleWeapon : WeaponBase
	{
		[SerializeField]
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
			var bullet = Instantiate (_bullet, transform.position, _bullet.transform.rotation) as IBullet;
            bullet.SetBulletInfo( Vector3.ProjectOnPlane(transform.up, Vector3.up).normalized, Range );
            if (_owner is PlayerUnitBase)
            {
                var player = _owner as PlayerUnitBase;
                var target = TapTargetManager.instance.TargetEnemy;
                if (target != null)
                {
                    bullet.SetBulletInfo( (target.transform.position - transform.position).normalized, Range );
                }
            }
            bullet.Owner = _owner;
		}
	}
}
