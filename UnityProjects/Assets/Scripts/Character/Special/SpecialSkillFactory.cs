using Google2u;

namespace YCG
{
    public static class SpecialSkillFactory
    {
        public static ISpecialSkill CreateSkill(Google2u.Player.rowIds id)
        {
            switch (id)
            {
                case Google2u.Player.rowIds.chr0001:
                    return new SkillChr0001();
                case Google2u.Player.rowIds.chr0002:
                    return new SkillChr0002();
                case Google2u.Player.rowIds.chr0003:
                    return new SkillChr0003();
                case Google2u.Player.rowIds.chr0004:
                    return new SkillChr0004();
                case Google2u.Player.rowIds.chr0005:
                    return new SkillChr0005();
                case Google2u.Player.rowIds.chr0006:
                    return new SkillChr0006();
                default:
                    return new SkillChr0001();
            }
        }
    }
}
