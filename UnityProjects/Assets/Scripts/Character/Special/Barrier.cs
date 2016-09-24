using UnityEngine;
using System.Collections;

namespace YCG
{
    public class Barrier : MonoBehaviour
    {
        private static readonly int Durability = 500;
        private int _damageAmount = 0;

        public void OnHitBullet(int damage)
        {
            _damageAmount += damage;
            if (_damageAmount > Durability)
            {
                Destroy(gameObject);
            }
        }
    }
}
