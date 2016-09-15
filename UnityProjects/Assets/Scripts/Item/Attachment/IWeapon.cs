
namespace YCG.Attachment
{
	public interface IWeapon
	{
        float Range { get; }
		float InvokeInterval { get; }
		void OnAttach();
		void OnDeattach();
		void OnInvoke(AttachmentArgs args);
	}

	public struct AttachmentArgs
	{
		public float BaseAttack;
	}
}
