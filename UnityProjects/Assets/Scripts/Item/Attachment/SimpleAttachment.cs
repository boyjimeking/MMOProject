using UnityEngine;
using System.Collections;

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
			bullet.Direction = transform.up;
            bullet.Owner = _owner;
		}
	}
}
