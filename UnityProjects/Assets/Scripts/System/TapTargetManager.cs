using UnityEngine;
using UnityEngine.EventSystems;
using YCG.YCInput;
using UnityEngine.Events;


namespace YCG
{
    public class TapTargetManager : SingletonBehaviour<TapTargetManager>
    {
		[SerializeField]
		private SpriteRenderer _debugMarker;

        public IEnemyUnit TargetEnemy { get; private set; }
        public Vector3 MoveTargetPos { get; private set; }

        public UnityEvent ChangeAttackTargetEvent { get; set; }
        public UnityEvent ChangeMoveTargetEvent { get; set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            ChangeAttackTargetEvent = new UnityEvent();
            ChangeMoveTargetEvent = new UnityEvent();
        }

        public void ResetTargetEnemy()
        {
            if (TargetEnemy != null)
            {
                TargetEnemy.Obj.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                TargetEnemy = null;
            }
        }

        private void SetTargetEnemy(IEnemyUnit enemy)
        {
            ResetTargetEnemy();
            if (enemy != TargetEnemy)
            {
                TargetEnemy = enemy;
                TargetEnemy.Obj.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                ChangeAttackTargetEvent.Invoke();
            }
        }

        public void OnDestroyEnemy(IEnemyUnit enemy)
        {
            if (TargetEnemy == enemy)
            {
                TargetEnemy = null;
            }
        }


        void Update()
        {
            if (YCGInput.TapAnyUGUI)
            {
                return;
            }

			if (YCGInput.TapDown) {
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
            Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Enemy"));
            if (hit.collider == null)
                return false;

            var enemy = hit.collider.gameObject.GetComponent<EnemyUnitBase>();
            if(enemy == null)
                return false;

            SetTargetEnemy(enemy);
            return true;
		}

        private void MoveToTapPos(Vector2 tapPos)
        {
			MoveTargetPos = Utility.ScreenPointToGroundPosition(tapPos);
			//debug
			_debugMarker.enabled = true;
			_debugMarker.transform.position = MoveTargetPos+0.001f*Vector3.up;

            ChangeMoveTargetEvent.Invoke();
        }
    }
}