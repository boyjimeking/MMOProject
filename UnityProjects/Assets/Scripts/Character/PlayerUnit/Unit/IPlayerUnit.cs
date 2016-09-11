using System.Collections.Generic;
using YCG.Attachment;

namespace YCG.Player
{
	public interface IPlayerUnit : ICharacterUnit
	{
		MyPlayerController Controller { get; }
		
		Dictionary<int, IAttachment> AttachmentList { get; }
		List<int> AttachmentCount { get; }
		List<int> RequiredExperiencePointList { get; }

		void AddAttachment(IAttachment attachment, int slot);
		void RemoveAttachment(int slot);
		void ChangeAttachment(IAttachment attachment, int slot);
	}
}