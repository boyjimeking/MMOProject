﻿using UnityEngine;
using System.Collections.Generic;
using YCG.Attachment;
using YCG.UI;

namespace YCG.Player
{
	public class PlayerUnitBase : MonoBehaviour, IPlayerUnit
	{
		public Transform Trans { get; private set; }
        public GameObject Obj { get; private set; }
		public MyPlayerController Controller { get; protected set; }
        public Vector3 MoveDir { get { return Controller.MoveDir; } }

        [SerializeField]
        Google2u.Player.rowIds _id;
        [SerializeField]
        WeaponBase _temporaryWeapon;
		public IWeapon Weapon { get; protected set; }
        public ISpecialSkill Skill { get; protected set; }
		public List<int> AttachmentCount { get; protected set; }
		public List<int> RequiredExperiencePointList { get; protected set; }
		public int MaxHP { get; protected set; }
		public int HP { get; protected set; }
        public int Heal { get; protected set; }
		public float Attack { get; protected set; }
		public float Speed { get; protected set; }
		public float Size { get; protected set; }

        #region Mono Method
        void Awake()
		{
			InitializeList ();
			InitializeParameter ();
            SetWeapon(_temporaryWeapon);
		}

        void Update()
        {
            if (Skill != null)
            {
                Skill.AdvanceCoolTime();
            }
        }
        #endregion

        public void InitializeList()
		{
			AttachmentCount = new List<int> ();
			RequiredExperiencePointList = new List<int> ();
		}

		public void InitializeParameter()
		{
            Trans = transform;
            Obj = gameObject;
            ResetParamter();
		}

        public void SetController(PlayerManager.ControlType type)
        {
			var attachedController = GetComponent<MyPlayerController> ();
            if (attachedController != null)
                DestroyImmediate(attachedController);

            switch (type)
            {
                case PlayerManager.ControlType.Self:
				    Controller = gameObject.AddComponent<MyPlayerController> ();
                    break;
                case PlayerManager.ControlType.Network:
                    //TODO:Implement
                    break;
                case PlayerManager.ControlType.AI:
                    //TODO:Implement
                    break;
            }

            Controller.Self = this;
        }

        public void ResetParamter()
        {
			var param = Google2u.Player.Instance.GetRow (_id);
			MaxHP = param._HP;
			HP = param._HP;
            Heal = param._Heal;
			Attack = param._Attack;
			Speed = param._Speed;
			Size = param._Size;
            Trans.localScale = Size * Vector3.one;
            Skill = SpecialSkillFactory.CreateSkill(_id);
            Skill.Owner = this;
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
            GUIManager.instance.SetHPView(HP, MaxHP);
        }
	}
}