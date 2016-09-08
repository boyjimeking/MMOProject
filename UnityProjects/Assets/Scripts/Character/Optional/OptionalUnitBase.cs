using UnityEngine;
using System.Collections;

namespace YCG
{
    public class OptionalUnitBase : AbstractMonoBehaviour, IOptionalUnit
    {

        public int HP { get; protected set; }
        public float Attack { get; protected set; }
        public float Speed { get; protected set; }
        public float Size { get; protected set; }

        public virtual void Death()
        {
            Destroy(gameObject);
        }

        public virtual void Damage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                Death();
            }
        }

        public virtual void Recover(int recover)
        {
            HP += recover;
        }
    }
}
