using UnityEngine;

namespace YCG.Attachment
{
	public interface IBullet
	{
        BulletParam Param { get; }
		ICharacterUnit Owner { get; set; }

        void SetBulletInfo(BulletParam param);
	}

    public struct BulletParam
    {
        public int Power;
        public float Speed;
        public float Range;
        public Vector3 Direction;
        public float LifeTime { get { return Range / Speed; } }
    }
}