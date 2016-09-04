using UnityEngine;
using System.Collections;
using YCG.YCInput;

namespace YCG.Player
{
	public class MyPlayerController : UnitControllerBase
	{
		protected override void OnAwake ()
		{
			base.OnAwake ();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if (InputManager.GetTapDown) {
				
			}
		}
	}
}
