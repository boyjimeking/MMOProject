using Google2u;

namespace YCG
{
    public static class SpecialSkillFactory
    {
        public static ISpecialSkill CreateSkill(Google2u.Player.rowIds id)
        {
            ISpecialSkill skill;
            switch (id)
            {
                case Google2u.Player.rowIds.chr0001:
                    skill = new SkillChr0001();
                    break;
                case Google2u.Player.rowIds.chr0002:
                    skill = new SkillChr0002();
                    break;
                case Google2u.Player.rowIds.chr0003:
                    skill = new SkillChr0003();
                    break;
                case Google2u.Player.rowIds.chr0004:
                    skill = new SkillChr0004();
                    break;
                case Google2u.Player.rowIds.chr0005:
                    skill = new SkillChr0005();
                    break;
                case Google2u.Player.rowIds.chr0006:
                    skill = new SkillChr0006();
                    break;
                default:
                    skill = new SkillChr0001();
                    break;
            }
            skill.Initialize();
            return skill;
        }
    }
}
