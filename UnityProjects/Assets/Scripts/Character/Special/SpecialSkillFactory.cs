using Google2u;

namespace YCG
{
    public static class SpecialSkillFactory
    {
        private static readonly float CoolTime0001 = 5f;
        private static readonly float CoolTime0002 = 5f;
        private static readonly float CoolTime0003 = 5f;
        private static readonly float CoolTime0004 = 5f;
        private static readonly float CoolTime0005 = 5f;
        private static readonly float CoolTime0006 = 5f;

        public static ISpecialSkill CreateSkill(Google2u.Player.rowIds id)
        {
            switch (id)
            {
                case Google2u.Player.rowIds.chr0001:
                    return new SkillChr0001(CoolTime0001);
                case Google2u.Player.rowIds.chr0002:
                    return new SkillChr0002(CoolTime0002);
                case Google2u.Player.rowIds.chr0003:
                    return new SkillChr0003(CoolTime0003);
                case Google2u.Player.rowIds.chr0004:
                    return new SkillChr0004(CoolTime0004);
                case Google2u.Player.rowIds.chr0005:
                    return new SkillChr0005(CoolTime0005);
                case Google2u.Player.rowIds.chr0006:
                    return new SkillChr0006(CoolTime0006);
                default:
                    return new SkillChr0001(CoolTime0001);
            }
        }
    }
}
