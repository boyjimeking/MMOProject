using UnityEngine;
using System.Collections;

namespace YCG.Attachment
{
	public class StraightBullet : BulletBase
	{
		[SerializeField]
		int _power;
		[SerializeField]
		float _speed;

		protected override void OnAwake ()
		{
			base.OnAwake ();
			Power = _power;
			Speed = _speed;
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			transform.position += Time.deltaTime * Speed * Direction;
		}
	}
}