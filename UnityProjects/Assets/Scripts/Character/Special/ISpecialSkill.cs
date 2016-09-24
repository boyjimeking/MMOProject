using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public interface ISpecialSkill
    {
        IPlayerUnit Owner { get; set; }
        float RemainingTime { get; }

        void Initialize();
        void InvokeSkill();
        void AdvanceCoolTime(float timeScale = 1f);
    }
}