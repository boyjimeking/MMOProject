using System.Collections.Generic;
using YCG.Attachment;

namespace YCG.Player
{
	public interface IPlayerUnit : ICharacterUnit
	{
		MyPlayerController Controller { get; }
		
		IWeapon Weapon { get; }
		List<int> AttachmentCount { get; }
		List<int> RequiredExperiencePointList { get; }

		void SetWeapon(IWeapon weapon);
	}
}