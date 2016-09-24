using UnityEngine;
using YCG.Player;

namespace YCG
{
    public abstract class SpecialSkillBase : ISpecialSkill
    {
        private readonly float BaseCoolTime = 5f;
        public IPlayerUnit Owner { get; set; }
        public float RemainingTime { get; private set; }
        public float CoolTime { get; protected set; }

        public virtual void Initialize()
        {
            CoolTime = BaseCoolTime;
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
