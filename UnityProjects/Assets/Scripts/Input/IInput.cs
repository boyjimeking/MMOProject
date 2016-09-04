using UnityEngine;

namespace YCG.YCInput
{
	public interface IInput
	{
		bool TapDown { get; }
		bool Tap { get; }
		bool TapUp { get; }
		Vector2 TapPosition { get; }
	}
}
