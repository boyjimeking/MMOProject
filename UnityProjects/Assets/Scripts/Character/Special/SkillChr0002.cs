using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public class SkillChr0002 : SpecialSkillBase
    {
        public List<IEnemyUnit> Targets { get; private set; }

        public SkillChr0002(float coolTime) : base(coolTime) { }

        protected override void OnInvoke()
        {
            base.OnInvoke();
            Targets = EnemyManager.instance.GetInRangeEnemys(Owner.Trans.position, 10);
            foreach(var target in Targets)
                target.Death();
        }
    }
}
