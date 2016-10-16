using UnityEngine;
using System.Collections.Generic;
using YCG.Attachment;
using YCG.UI;

namespace YCG.Player
{
	public interface IPlayerUnit : ICharacterUnit
	{
		MyPlayerController Controller { get; }
        Vector3 MoveDir { get; }
		
        int Heal { get; }
		IWeapon Weapon { get; }
        ISpecialSkill Skill { get; }
		List<int> AttachmentCount { get; }
		List<int> RequiredExperiencePointList { get; }

		void SetWeapon(IWeapon weapon);
		void InvokeSkill();
	}
}