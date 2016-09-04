using UnityEngine;
using System.Collections.Generic;

namespace YCG.Player
{
	public class UnitBase : MonoBehaviour, IPlayerUnit
	{
		public IPlayerUnitController Controller { get; protected set; }
		
		public List<IAttachment> AttachmentList { get; protected set; }
		public List<int> AttachmentCount { get; protected set; }
		public List<int> RequiredExperiencePointList { get; protected set; }
		public int HP { get; protected set; }
		public float Attack { get; protected set; }
		public float Speed { get; protected set; }
		public float Size { get; protected set; }

		void Awake()
		{
			InitializeParameter ();
		}
		//FIXME:Debug
		public void InitializeParameter()
		{
			var attachedController = GetComponent<IPlayerUnitController> ();
			if (attachedController == null)
				Controller = gameObject.AddComponent<MyPlayerController> ();
			else
				Controller = attachedController;
			HP = 10;
			Attack = 1.0f;
			Speed = 5.0f;
			Size = 1.0f;
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