using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace YCG.Player
{
	public abstract class UnitControllerBase : AbstractMonoBehaviour, IPlayerUnitController 
	{
        public IPlayerUnit Self { get; set; }
        public Vector3 MoveDir { get; protected set; }

		Tweener _moveTwinner;

		protected override void OnAwake ()
		{
			base.OnAwake ();
            MoveDir = new Vector3(-1,0,1).normalized;
		}

		protected void MoveTo(Vector3 to, Action onComplete)
		{
			if (_moveTwinner != null)
			{
				_moveTwinner.Kill ();
			}
			float dist = Vector3.Distance (transform.position, to);
            MoveDir = (to - transform.position).normalized;
			_moveTwinner = transform.DOMove (to, 0.2f * dist).SetEase (Ease.Linear).OnComplete(()=>{
				_moveTwinner = null;
				onComplete();
			});
		}
	}
}
