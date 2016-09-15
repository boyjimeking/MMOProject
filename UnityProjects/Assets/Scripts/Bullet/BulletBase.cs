using UnityEngine;
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

		protected virtual void OnHitBullet (ICharacterUnit hitUnit)
		{
            hitUnit.Damage(Power);
            Destroy(gameObject);
		}

        void OnTriggerEnter(Collider hitCol)
        {
            var character = hitCol.GetComponent<ICharacterUnit>();
            if (Owner == null)
                return;
            if (character == null)
                return;

            if (Owner is IEnemyUnit && character is IPlayerUnit
                || Owner is IPlayerUnit && character is IEnemyUnit)
            {
                OnHitBullet(character);
            }
        }
	}
}