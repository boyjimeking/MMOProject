using UnityEngine;
using YCG.Player;

namespace YCG.Attachment
{
	public class SimpleAttachment : AttachmentBase
	{
		[SerializeField]
		BulletBase _bullet;

		protected override void OnAwake ()
		{
			base.OnAwake ();
			_invokeType = InvokeType.ConstInterval;
		}

		public override void OnInvoke (AttachmentArgs args)
		{
			base.OnInvoke (args);
			var bullet = Instantiate (_bullet, transform.position, _bullet.transform.rotation) as IBullet;
            bullet.Direction = Vector3.ProjectOnPlane(transform.up, Vector3.up).normalized;
            if (_owner is PlayerUnitBase)
            {
                var player = _owner as PlayerUnitBase;
                var target = player.Controller.TargetEnemy;
                if (target != null)
                {
                    bullet.Direction = (target.transform.position - transform.position).normalized;
                }
            }
            bullet.Owner = _owner;
		}
	}
}
