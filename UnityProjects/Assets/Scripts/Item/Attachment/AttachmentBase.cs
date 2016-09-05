using UnityEngine;
using System.Collections;

namespace YCG.Attachment
{
	public abstract class AttachmentBase : MonoBehaviour, IAttachment
	{
		protected InvokeType _invokeType;
		protected float _invokeInterval = 1.0f;
		private float _elapsedTime;

		void Awake()
		{
			OnAwake ();
		}

		protected virtual void OnAwake()
		{
		}

		void Update()
		{
			OnUpdate ();
			var args = new AttachmentArgs () {
				BaseAttack = 1f
			};
			switch(_invokeType)
			{
			case InvokeType.Always:
				OnInvoke (args);
				break;
			case InvokeType.ConstInterval:
				if (_elapsedTime > _invokeInterval) {
					OnInvoke (args);
					_elapsedTime = 0f;
				}
				_elapsedTime += Time.deltaTime;
				break;
			}
		}

		protected virtual void OnUpdate()
		{
		}

		public virtual void OnAttach()
		{
		}

		public virtual void OnDeattach()
		{
		}

		public virtual void OnInvoke(AttachmentArgs args)
		{
		}
	}

	public enum InvokeType
	{
		Always,
		ConstInterval,
	}

}
