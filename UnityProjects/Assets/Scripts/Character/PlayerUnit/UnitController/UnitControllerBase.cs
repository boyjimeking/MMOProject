using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace YCG.Player
{
	public abstract class UnitControllerBase : AbstractMonoBehaviour, IPlayerUnitController 
	{
        public IPlayerUnit Self { get; set; }

		Tweener _moveTwinner;

		protected void MoveTo(Vector3 to, Action onComplete)
		{
			if (_moveTwinner != null)
			{
				_moveTwinner.Kill ();
			}
			float dist = Vector3.Distance (transform.position, to);
			_moveTwinner = transform.DOMove (to, 0.2f * dist).SetEase (Ease.Linear).OnComplete(()=>{
				_moveTwinner = null;
				onComplete();
			});
		}
	}
}
