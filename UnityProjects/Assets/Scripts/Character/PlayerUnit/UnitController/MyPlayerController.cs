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
            TapTargetManager.instance.ChangeAttackTargetEvent.AddListener(OnChangeAttackTarget);
		}

        private void OnChangeMoveTarget()
        {
            Vector3 toPos = TapTargetManager.instance.MoveTargetPos;
            MoveTo(toPos, ()=>{ CheckResetEnemyTarget(toPos); });
        }

        private void OnChangeAttackTarget()
        {
            Vector3 targetPos = TapTargetManager.instance.TargetEnemy.transform.position;
            Vector3 myPos = transform.position;
            Vector3 diff = targetPos - myPos;
            float dist = diff.magnitude;
            if (dist > Self.Weapon.Range)
            {
                Vector3 toPos = Vector3.Lerp(targetPos, myPos, Self.Weapon.Range / dist);
                MoveTo(toPos, () => { });
            }
        }

        private void CheckResetEnemyTarget(Vector3 toPos)
        {
            var enemy = TapTargetManager.instance.TargetEnemy;
            if (enemy == null)
                return;

            Vector3 targetPos = enemy.transform.position;
            Vector3 myPos = transform.position;
            float sqrDist = (targetPos - myPos).sqrMagnitude;
            if (sqrDist > Self.Weapon.Range * Self.Weapon.Range)
            {
                TapTargetManager.instance.ResetTargetEnemy();
            }
        }
	}
}
