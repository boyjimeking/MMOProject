using UnityEngine;

namespace YCG
{
	public static class Utility
	{
		private readonly static Plane _groundPlane = new Plane(Vector3.up, Vector3.zero);
		public static Vector3 ScreenPointToGroundPosition(Vector2 point)
		{
			Ray ray = Camera.main.ScreenPointToRay (point);
			float dist;
			_groundPlane.Raycast (ray, out dist);
			return ray.GetPoint (dist);
		}

	}
}