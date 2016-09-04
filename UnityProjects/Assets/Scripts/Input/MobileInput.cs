using UnityEngine;
using System.Collections;

namespace YCG.YCInput
{
	public class MobileInput : IInput
	{

		public bool GetTapDown { 
			get
			{
				return IsValidTouchCount (1) && Input.GetTouch (0).phase == TouchPhase.Began;
			}
		}

		public bool GetTap { 
			get
			{
				return IsValidTouchCount (1) && Input.GetTouch (0).phase == TouchPhase.Moved;
			}
		}

		public bool GetTapUp { 
			get
			{
				return IsValidTouchCount (1) && Input.GetTouch (0).phase == TouchPhase.Ended;
			}
		}

		public Vector2 GetTapPosition
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
