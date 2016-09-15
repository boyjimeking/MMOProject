using UnityEngine;

namespace YCG.Attachment
{
	public interface IBullet
	{
		int Power { get; }
		float Speed { get; }
		float LifeTime { get; }
		Vector3 Direction { get; }
		ICharacterUnit Owner { get; set; }

        void SetBulletInfo(Vector3 dir, float range);
	}
}