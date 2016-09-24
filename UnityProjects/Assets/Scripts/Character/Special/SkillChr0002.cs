using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public class SkillChr0002 : SpecialSkillBase
    {
        private readonly float SkillCoolTime = 5f;
        public List<IEnemyUnit> Targets { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
            CoolTime = SkillCoolTime;
        }

        protected override void OnInvoke()
        {
            base.OnInvoke();
            Targets = EnemyManager.instance.GetInRangeEnemys(Owner.Trans.position, 10);
            foreach(var target in Targets)
                target.Death();
        }
    }
}
