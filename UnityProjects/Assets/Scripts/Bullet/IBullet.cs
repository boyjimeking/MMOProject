using UnityEngine;

namespace YCG.Attachment
{
	public interface IBullet
	{
		int Power { get; set; }
		float Speed { get; set; }
		Vector3 Direction { get; set; }
	}
}