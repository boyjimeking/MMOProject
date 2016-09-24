using UnityEngine;
using YCG.Player;

namespace YCG
{
    public abstract class SpecialSkillBase : ISpecialSkill
    {
        public IPlayerUnit Owner { get; set; }
        public float RemainingTime { get; private set; }
        public float CoolTime { get; private set; }

        public SpecialSkillBase(float coolTime)
        {
            CoolTime = coolTime;
        }

        public void InvokeSkill()
        {
            if (RemainingTime <= 0f)
            {
                OnInvoke();
                RemainingTime = CoolTime;
            }
        }

        public void AdvanceCoolTime(float timeScale = 1f)
        {
            RemainingTime -= timeScale * Time.deltaTime;
        }

        protected virtual void OnInvoke()
        {
        }
    }
}
