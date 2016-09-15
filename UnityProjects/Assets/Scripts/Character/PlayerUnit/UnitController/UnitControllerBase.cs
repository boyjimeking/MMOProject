using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace YCG.Player
{
	public abstract class UnitControllerBase : AbstractMonoBehaviour, IPlayerUnitController 
	{
        public IPlayerUnit Self { get; set; }

		protected void MoveTo(Vector3 to, Action onComplete)
		{
			float dist = Vector3.Distance (transform.position, to);
			transform.DOMove (to, 0.2f * dist).SetEase (Ease.Linear).OnComplete(()=>{
				onComplete();
			});
		}
	}
}
