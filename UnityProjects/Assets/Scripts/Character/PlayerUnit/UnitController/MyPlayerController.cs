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

        public EnemyUnitBase TargetEnemy { get; private set; }

		protected override void OnAwake ()
		{
			base.OnAwake ();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
			if (YCGInput.TapDown) {
                if (TargetEnemy != null)
                {
                    TargetEnemy.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    TargetEnemy = null;
                }
			    Vector2 tapPos = YCGInput.TapPosition;
                //ターゲット取るか移動か
                if (MakeAttackTarget(tapPos) == false)
                {
                    MoveToTapPos(tapPos);
                }
			}
		}

		private bool MakeAttackTarget(Vector2 tapPos)
		{
			Ray ray = Camera.main.ScreenPointToRay (tapPos);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider == null)
                return false;

            var enemy = hit.collider.gameObject.GetComponent<EnemyUnitBase>();
            if(enemy == null)
                return false;

            TargetEnemy = enemy;
            TargetEnemy.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            return true;
		}

        private void MoveToTapPos(Vector2 tapPos)
        {
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
