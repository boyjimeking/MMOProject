using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public class SkillChr0003 : ISpecialSkill
    {
        public IPlayerUnit Owner { get; set; }
        public IEnemyUnit Target { get; private set; }

        public void InvokeSkill()
        {
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
                Target = EnemyManager.instance.GetNearestEnemy(Owner.Trans.position);
            }
        }
    }
}
