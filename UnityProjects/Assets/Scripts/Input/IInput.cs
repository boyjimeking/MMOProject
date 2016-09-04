using UnityEngine;

namespace YCG.YCInput
{
	public interface IInput
	{
		bool GetTapDown { get; }
		bool GetTap { get; }
		bool GetTapUp { get; }
		Vector2 GetTapPosition { get; }
	}
}
