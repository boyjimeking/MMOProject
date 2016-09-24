using UnityEngine;
using YCG;
using YCG.Player;

namespace YCG.Attachment
{
	public abstract class BulletBase : AbstractMonoBehaviour, IBullet
	{
		[SerializeField]
		int _power = 2;
		[SerializeField]
		float _speed = 10f;
        float _elapsedTime = 0f;

		public int Power { get; private set; }
		public float Speed { get; private set; }
		public float LifeTime { get; private set; }
		public Vector3 Direction { get; private set; }
		public ICharacterUnit Owner { get; set; }

		protected override void OnAwake ()
		{
			base.OnAwake ();
			Power = _power;
			Speed = _speed;
		}

		protected override void OnUpdate ()
		{
			base.OnUpdate ();
            if (_elapsedTime > LifeTime)
            {
                Destroy(gameObject);
            }
            _elapsedTime += Time.deltaTime;
		}

        public void SetBulletInfo(Vector3 dir, float range)
        {
            Direction = dir;
            LifeTime = range / Speed;
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
            barrier.OnHitBullet(Power);
            Destroy(gameObject);
        }

		protected virtual void OnHitBullet (ICharacterUnit hitUnit)
		{
            hitUnit.Damage(Power);
            Destroy(gameObject);
		}

	}
}