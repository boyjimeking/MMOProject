using UnityEngine;
using System.Collections;

namespace YCG.Player
{
	public abstract class UnitControllerBase : MonoBehaviour, IPlayerUnitController 
	{
		void Awake()
		{
		}

		protected virtual void OnAwake()
		{
		}

		void Update()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected void MoveTo(Vector3 to)
		{
			transform.position = to;
		}
	}
}
