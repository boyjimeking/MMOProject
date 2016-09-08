using UnityEngine;
using System.Collections;
using YCG.YCInput;
using DG.Tweening;

namespace YCG.Player
{
	public class MyPlayerController : UnitControllerBase
	{
		[SerializeField]
		private SpriteRenderer _debugMarker;
		[SerializeField]
		private LineRenderer _debugNaviLine;


		protected override void OnAwake ()
		{
			base.OnAwake ();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if (YCGInput.TapDown) {
				Vector2 tapPos = YCGInput.TapPosition;
				Vector3 toPos = Utility.ScreenPointToGroundPosition(tapPos);
				transform.DOKill ();
				MoveTo (toPos, ()=>{
					_debugMarker.enabled = false;
					_debugNaviLine.enabled = false;
				});

				//debug
				_debugMarker.enabled = true;
				_debugNaviLine.enabled = true;
				_debugMarker.transform.position = toPos;
				_debugNaviLine.SetPosition (0, transform.position);
				_debugNaviLine.SetPosition (1, toPos);
			}
		}
	}
}
