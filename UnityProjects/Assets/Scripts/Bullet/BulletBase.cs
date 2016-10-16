using UnityEngine;
using YCG;
using YCG.Player;

namespace YCG.Attachment
{
	public abstract class BulletBase : AbstractMonoBehaviour, IBullet
	{
        float _elapsedTime = 0f;

        bool _enabled = true;
        public bool Enabled {
            get {
                return _enabled;
            }
            set {
                _enabled = value;
                Obj.SetActive(value);
                _elapsedTime = 0f;
            }
        }
        public GameObject Obj { get; private set; }
        public Transform Trans { get; private set; }
		public BulletParam Param { get; private set; }
		public ICharacterUnit Owner { get; set; }

		protected override void OnAwake ()
		{
			base.OnAwake ();
            Obj = gameObject;
            Trans = transform;
		}

		protected override void OnUpdate ()
		{
            if (Enabled == false)
                return;

			base.OnUpdate ();
            if (_elapsedTime > Param.LifeTime)
            {
                Release();
            }
            _elapsedTime += Time.deltaTime;
		}

        public void SetBulletInfo(BulletParam param)
        {
            Param = param;
        }

        void OnTriggerEnter(Collider hitCol)
        {
            if (Owner == null)
                return;

            var barrier = hitCol.GetComponent<Barrier>();
            if (HitBarrier(barrier))
                return;

            var character = hitCol.GetComponent<ICharacterUnit>();
            HitCharacter(character);

        }

        private bool HitBarrier(Barrier barrier)
        {
            if (barrier == null)
                return false;

            if (Owner is IEnemyUnit)
            {
                OnHitBarrier(barrier);
                return true;
            }
            return false;
        }

        private bool HitCharacter(ICharacterUnit character)
        {
            if (character == null)
                return false;

            if (Owner is IEnemyUnit && character is IPlayerUnit
                || Owner is IPlayerUnit && character is IEnemyUnit)
            {
                OnHitBullet(character);
                return true;
            }
            return false;
        }

        protected virtual void OnHitBarrier(Barrier barrier)
        {
            barrier.OnHitBullet(Param.Power);
            Release();
        }

		protected virtual void OnHitBullet (ICharacterUnit hitUnit)
		{
            hitUnit.Damage(Param.Power);
            Release();
		}

        private void Release()
        {
            GameManager.instance.BulletManager.OnReleaseBullet(this);
        }
	}
}