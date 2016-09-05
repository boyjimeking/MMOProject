
namespace YCG.Attachment
{
	public interface IAttachment
	{
		void OnAttach();
		void OnDeattach();
		void OnInvoke(AttachmentArgs args);
	}

	public struct AttachmentArgs
	{
		public float BaseAttack;
	}
}
