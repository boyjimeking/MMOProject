using UnityEngine;
using System.Collections;

namespace YCG
{
	public interface ICharacterUnit
	{
		int HP { get; }
		float Attack { get; }
		float Speed { get; }
		float Size { get; }

		void Damage(int damage);
		void Recover(int recover);
	}
}
