using System.Collections.Generic;

namespace YCG.Player
{
	public interface IPlayerUnit
	{
		IPlayerUnitController Controller { get; }
		
		List<IAttachment> AttachmentList { get; }
		List<int> AttachmentCount { get; }
		List<int> RequiredExperiencePointList { get; }
		int HP { get; }
		float Attack { get; }
		float Speed { get; }
		float Size { get; }

		void Damage(int damage);
		void Recover(int recover);
	}
}