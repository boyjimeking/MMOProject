using UnityEngine;
using System.Collections;

namespace YCG.Attachment
{
	public class StraightBullet : BulletBase
	{
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			transform.position += Time.deltaTime * Param.Speed * Param.Direction;
		}
	}
}