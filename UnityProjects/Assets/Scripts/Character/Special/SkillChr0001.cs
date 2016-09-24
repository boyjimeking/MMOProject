using YCG.Attachment;

namespace YCG
{
    public class SkillChr0001 : SpecialSkillBase
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
                var param = new BulletParam()
                {
                    Power = 10000,
                    Speed = 100f,
                    Range = 50f,
                    Direction = (Target.Trans.position - Owner.Trans.position).normalized
                };
                BulletManager.instance.ShotStraightBullet(param, Owner, Owner.Trans.position);
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
