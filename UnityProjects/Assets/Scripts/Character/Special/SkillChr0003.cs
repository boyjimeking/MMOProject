using UnityEngine;

namespace YCG
{
    public class SkillChr0003 : SpecialSkillBase
    {
        private readonly float SkillCoolTime = 20f;
        public IEnemyUnit Target { get; private set; }
        private Barrier _barrier;

        public override void Initialize()
        {
            base.Initialize();
            CoolTime = SkillCoolTime;
            _barrier = Resources.Load<Barrier>("Prefabs/Skill/Barrier");
        }

        protected override void OnInvoke()
        {
            base.OnInvoke();
            var barrier = GameObject.Instantiate(_barrier, Owner.Trans.position, _barrier.transform.rotation) as Barrier;
            barrier.transform.SetParent(Owner.Trans);
        }
    }
}
