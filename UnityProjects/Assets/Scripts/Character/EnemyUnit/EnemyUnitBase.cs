using UnityEngine;
using System.Collections;

namespace YCG
{
	public abstract class EnemyUnitBase : AbstractMonoBehaviour, IEnemyUnit
	{
        public Transform Trans { get; private set; }
        public GameObject Obj { get; private set; }

		public int HP { get; protected set; }
		public float Attack { get; protected set; }
		public float Speed { get; protected set; }
		public float Size { get; protected set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            Trans = transform;
            Obj = gameObject;
        }

        public virtual void Death()
		{
            GameManager.instance.EnemyManager.OnDeathEnemy(this);
            TapTargetManager.instance.OnDestroyEnemy(this);
			Destroy (Obj);
		}

		public virtual void Damage(int damage)
		{
			HP -= damage;
            if (HP <= 0)
            {
                Death();
            }
		}

		public virtual void Recover(int recover)
		{
			HP += recover;
		}
	}
}