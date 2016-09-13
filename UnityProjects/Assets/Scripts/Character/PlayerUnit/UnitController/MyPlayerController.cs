using UnityEngine;
using System.Collections;
using YCG.YCInput;
using DG.Tweening;

namespace YCG.Player
{
	public class MyPlayerController : UnitControllerBase
	{

		protected override void OnAwake ()
		{
			base.OnAwake ();
            TapTargetManager.instance.ChangeMoveTargetEvent.AddListener(OnChangeMoveTarget);
		}

        private void OnChangeMoveTarget()
        {
            Vector3 toPos = TapTargetManager.instance.MoveTargetPos;
            MoveTo(toPos, ()=>{});
        }
	}
}
