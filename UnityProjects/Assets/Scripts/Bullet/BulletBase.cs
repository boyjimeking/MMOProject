using UnityEngine;
using System.Collections;

namespace YCG.Attachment
{
	public class BulletBase : MonoBehaviour, IBullet
	{
		public int Power { get; set; }
		public float Speed { get; set; }
		public Vector3 Direction { get; set; }

		void Awake () 
		{
			OnAwake ();
		}

		protected virtual void OnAwake()
		{
		}
		
		void Update () 
		{
			OnUpdate ();
		}

		protected virtual void OnUpdate()
		{
		}
	}
}