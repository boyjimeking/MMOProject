using UnityEngine;
using System.Collections;

namespace YCG
{
    public class OptionalUnitBase : AbstractMonoBehaviour, IOptionalUnit
    {
        public Transform Trans { get; private set; }
        public GameObject Obj { get; private set; }

        public int HP { get; protected set; }
        public float Attack { get; protected set; }
        public float Speed { get; protected set; }
        public float Size { get; protected set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            Trans = transform;
            Obj = gameObject;
        }

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
