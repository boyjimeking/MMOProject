using System.Collections.Generic;
using YCG.Attachment;

namespace YCG.Player
{
	public interface IPlayerUnit
	{
		IPlayerUnitController Controller { get; }
		
		Dictionary<int, IAttachment> AttachmentList { get; }
		List<int> AttachmentCount { get; }
		List<int> RequiredExperiencePointList { get; }
		int HP { get; }
		float Attack { get; }
		float Speed { get; }
		float Size { get; }

		void AddAttachment(IAttachment attachment, int slot);
		void RemoveAttachment(int slot);
		void ChangeAttachment(IAttachment attachment, int slot);
		void Damage(int damage);
		void Recover(int recover);
	}
}