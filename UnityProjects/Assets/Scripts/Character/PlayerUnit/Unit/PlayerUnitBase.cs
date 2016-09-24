using UnityEngine;
using System.Collections.Generic;
using YCG.Attachment;

namespace YCG.Player
{
	public class PlayerUnitBase : MonoBehaviour, IPlayerUnit
	{
		public Transform Trans { get; private set; }
        public GameObject Obj { get; private set; }
		public MyPlayerController Controller { get; protected set; }
        public Vector3 MoveDir { get { return Controller.MoveDir; } }

        [SerializeField]
        SimpleHPView _hpView;
		public IHPView HPView { get; protected set; }
        [SerializeField]
        WeaponBase _temporaryWeapon;
		public IWeapon Weapon { get; protected set; }
        public ISpecialSkill Skill { get; protected set; }
		public List<int> AttachmentCount { get; protected set; }
		public List<int> RequiredExperiencePointList { get; protected set; }
		public int MaxHP { get; protected set; }
		public int HP { get; protected set; }
		public float Attack { get; protected set; }
		public float Speed { get; protected set; }
		public float Size { get; protected set; }

		void Awake()
		{
			InitializeList ();
			InitializeParameter ();
            HPView = _hpView;
            SetWeapon(_temporaryWeapon);
		}

		public void InitializeList()
		{
			AttachmentCount = new List<int> ();
			RequiredExperiencePointList = new List<int> ();
		}

		public void InitializeParameter()
		{
            Trans = transform;
            Obj = gameObject;
			var attachedController = GetComponent<MyPlayerController> ();
			if (attachedController == null)
				Controller = gameObject.AddComponent<MyPlayerController> ();
			else
				Controller = attachedController;
            Controller.Self = this;
            Skill = new SimpleSpecialSkill();
            Skill.Owner = this;

			var param = Google2u.Player.Instance.GetRow (0);
			MaxHP = param._HP;
			HP = param._HP;
			Attack = param._Attack;
			Speed = param._Speed;
			Size = param._Size;
		}

		public virtual void SetWeapon(IWeapon weapon)
		{
            Weapon = weapon;
		}

        public virtual void InvokeSkill()
        {
            if (Skill != null)
                Skill.InvokeSkill();
        }

		public virtual void Death()
		{
            GameManager.instance.OnPlayerDeath();
		}

		public virtual void Damage(int damage)
		{
            SetHP(HP - damage);
            if (HP <= 0)
            {
                Death();
            }
		}

		public virtual void Recover(int recover)
		{
            SetHP(HP + recover);
		}

        private void SetHP(int value)
        {
            HP = value;
            HPView.SetHPValue(HP, MaxHP);
        }
	}
}