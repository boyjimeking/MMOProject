using UnityEngine;

namespace YCG.Player
{
	public interface IPlayerUnitController
	{
        IPlayerUnit Self { get; set; }
		Transform transform { get; }
        Vector3 MoveDir { get; }
	}
}