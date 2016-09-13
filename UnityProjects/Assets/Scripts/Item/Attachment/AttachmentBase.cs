using UnityEngine;
using System.Collections;

namespace YCG.Attachment
{
	public abstract class AttachmentBase : AbstractMonoBehaviour, IAttachment
	{
		protected ICharacterUnit _owner;
		protected InvokeType _invokeType;
		protected float _invokeInterval = 0.25f;
		private float _elapsedTime;

        protected override void OnAwake()
        {
            base.OnAwake();
            _owner = GetComponentInParent<ICharacterUnit>();
        }

		protected override void OnUpdate()
		{
			base.OnUpdate ();
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
