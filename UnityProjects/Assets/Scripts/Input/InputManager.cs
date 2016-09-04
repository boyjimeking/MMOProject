using UnityEngine;
using System.Collections;

namespace YCG.YCInput
{
	public static class InputManager
	{
		private static IInput _input;
		public static void Initialize()
		{
			#if UNITY_ANDROID || UNITY_IOS
			_input = new MobileInput();
			#else
			_input = new PCInput();
			#endif
		}

		public static bool GetTapDown {	get { return _input.GetTapDown; } }

		public static bool GetTap {	get { return _input.GetTap; } }

		public static bool GetTapUp {	get { return _input.GetTapUp; } }

		public static Vector2 GetTapPosition {	get { return _input.GetTapPosition; } }
	}
}
