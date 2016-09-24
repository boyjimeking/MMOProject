using System.Collections.Generic;
using YCG.Attachment;

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
            foreach (var target in Targets)
            {
                var param = new BulletParam()
                {
                    Power = 10000,
                    Speed = 50f,
                    Range = 50f,
                    Direction = (target.Trans.position - Owner.Trans.position).normalized
                };
                BulletManager.instance.ShotStraightBullet(param, Owner, Owner.Trans.position);
            }
        }
    }
}
