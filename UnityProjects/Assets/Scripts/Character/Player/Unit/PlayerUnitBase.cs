using UnityEngine;
using System.Collections.Generic;
using YCG.Attachment;

namespace YCG.Player
{
	public class PlayerUnitBase : MonoBehaviour, IPlayerUnit
	{
		[SerializeField]
		AttachmentBase _debugAttachment;

		public IPlayerUnitController Controller { get; protected set; }
		
		public Dictionary<int, IAttachment> AttachmentList { get; protected set; }
		public List<int> AttachmentCount { get; protected set; }
		public List<int> RequiredExperiencePointList { get; protected set; }
		public int HP { get; protected set; }
		public float Attack { get; protected set; }
		public float Speed { get; protected set; }
		public float Size { get; protected set; }

		void Awake()
		{
			InitializeList ();
			InitializeParameter ();
		}

		public void InitializeList()
		{
			AttachmentList = new Dictionary<int, IAttachment> ();
			AttachmentCount = new List<int> ();
			RequiredExperiencePointList = new List<int> ();
		}

		//FIXME:Debug
		public void InitializeParameter()
		{
			AddAttachment (_debugAttachment, 0);
			var attachedController = GetComponent<IPlayerUnitController> ();
			if (attachedController == null)
				Controller = gameObject.AddComponent<MyPlayerController> ();
			else
				Controller = attachedController;
			var param = Google2u.Player.Instance.GetRow (0);
			HP = param._HP;
			Attack = param._Attack;
			Speed = param._Speed;
			Size = param._Size;
		}

		public virtual void AddAttachment(IAttachment attachment, int slot)
		{
			AttachmentList [slot] = attachment;
		}

		public virtual void RemoveAttachment(int slot)
		{
			AttachmentList.Remove (slot);
		}

		public virtual void ChangeAttachment(IAttachment attachment, int slot)
		{
			RemoveAttachment (slot);
			AddAttachment (attachment, slot);
		}

		public virtual void Damage(int damage)
		{
			HP -= damage;
		}

		public virtual void Recover(int recover)
		{
			HP += recover;
		}
	}
}