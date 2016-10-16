using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public class SkillChr0004 : SpecialSkillBase
    {
        private readonly float SkillCoolTime = 5f;
        public IEnemyUnit Target { get; protected set; }

        public override void Initialize()
        {
            base.Initialize();
            CoolTime = SkillCoolTime;
        }

        protected override void OnInvoke()
        {
            base.OnInvoke();
            CreateTargetList();
            if (Target != null)
            {
                Target.Death();
            }
        }

        private void CreateTargetList()
        {
            Target = TapTargetManager.instance.TargetEnemy;
            if (Target == null)
            {
                Target = GameManager.instance.EnemyManager.GetNearestEnemy(Owner.Trans.position);
            }
        }
    }
}
