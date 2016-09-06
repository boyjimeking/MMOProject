using UnityEngine;

namespace YCG.Attachment
{
	public interface IBullet
	{
		int Power { get; }
		float Speed { get; }
		float LifeTime { get; }
		Vector3 Direction { get; set; }
		ICharacterUnit Owner { get; set; }
	}
}