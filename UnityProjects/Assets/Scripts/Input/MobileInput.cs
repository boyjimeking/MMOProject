using UnityEngine;
using System.Collections;

namespace YCG.YCInput
{
	public class MobileInput : IInput
	{

		public bool TapDown { 
			get
			{
				return IsValidTouchCount (1) && Input.GetTouch (0).phase == TouchPhase.Began;
			}
		}

		public bool Tap { 
			get
			{
				return IsValidTouchCount (1) && Input.GetTouch (0).phase == TouchPhase.Moved;
			}
		}

		public bool TapUp { 
			get
			{
				return IsValidTouchCount (1) && Input.GetTouch (0).phase == TouchPhase.Ended;
			}
		}

		public Vector2 TapPosition
		{
			get 
			{
				if (IsValidTouchCount (1))
					return Input.GetTouch (0).position;
				else
					return Vector2.zero;
			}
		}

		private static bool IsValidTouchCount(int count)
		{
			return count <= Input.touchCount;
		}
	}
}
