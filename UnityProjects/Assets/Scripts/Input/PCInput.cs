using UnityEngine;
using UnityEngine.EventSystems;

namespace YCG.YCInput
{
	public class PCInput : IInput
	{
		public bool TapDown 
		{ 
			get
			{
				return Input.GetMouseButtonDown (0);
			}
		}

		public bool Tap 
		{
			get
			{
				return Input.GetMouseButton (0);
			}
		}

		public bool TapUp 
		{ 
			get
			{
				return Input.GetMouseButtonUp (0);
			}
		}

		public bool TapAnyUGUI { 
			get
			{
                return EventSystem.current.IsPointerOverGameObject();
			}
		}

		public Vector2 TapPosition
		{
			get 
			{
				return Input.mousePosition;
			}
		}
	}
}
