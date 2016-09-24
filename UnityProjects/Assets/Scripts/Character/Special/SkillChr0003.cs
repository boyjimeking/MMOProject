﻿using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public class SkillChr0003 : SpecialSkillBase
    {
        public IEnemyUnit Target { get; private set; }

        public SkillChr0003(float coolTime) : base(coolTime) { }

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
                Target = EnemyManager.instance.GetNearestEnemy(Owner.Trans.position);
            }
        }
    }
}
