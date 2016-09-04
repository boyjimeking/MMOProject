using UnityEngine;
using System.Collections;

namespace YCG
{
	public class EnvironmentInitializer : MonoBehaviour 
	{
		void Awake()
		{
			YCInput.InputManager.Initialize ();
		}
	}
}