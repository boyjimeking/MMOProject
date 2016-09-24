using UnityEngine;
using YCG;
using YCG.Player;

namespace YCG.Attachment
{
	public abstract class BulletBase : AbstractMonoBehaviour, IBullet
	{
        float _elapsedTime = 0f;

		public BulletParam Param { get; private set; }
		public ICharacterUnit Owner { get; set; }

		protected override void OnAwake ()
		{
			base.OnAwake ();
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
            if (_elapsedTime > Param.LifeTime)
            {
                Destroy(gameObject);
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
            Destroy(gameObject);
        }

		protected virtual void OnHitBullet (ICharacterUnit hitUnit)
		{
            hitUnit.Damage(Param.Power);
            Destroy(gameObject);
		}

	}
}