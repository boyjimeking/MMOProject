using System.Collections.Generic;
using YCG.Player;

namespace YCG
{
    public interface ISpecialSkill
    {
        IPlayerUnit Owner { get; set; }
        void InvokeSkill();
    }
}