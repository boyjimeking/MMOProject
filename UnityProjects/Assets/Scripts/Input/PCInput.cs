using UnityEngine;

namespace YCG.YCInput
{
	public class PCInput : IInput
	{
		public bool GetTapDown 
		{ 
			get
			{
				return Input.GetMouseButtonDown (0);
			}
		}

		public bool GetTap 
		{
			get
			{
				return Input.GetMouseButton (0);
			}
		}

		public bool GetTapUp 
		{ 
			get
			{
				return Input.GetMouseButtonUp (0);
			}
		}

		public Vector2 GetTapPosition
		{
			get 
			{
				return Input.mousePosition;
			}
		}
	}
}
