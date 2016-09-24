using UnityEngine;

namespace YCG
{
	public interface ICharacterUnit
	{
        Transform Trans { get; }
        GameObject Obj { get; }

		int HP { get; }
		float Attack { get; }
		float Speed { get; }
		float Size { get; }

		void Death();
		void Damage(int damage);
		void Recover(int recover);
	}
}
