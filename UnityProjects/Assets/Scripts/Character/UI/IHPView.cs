using UnityEngine;
using System.Collections;

namespace YCG
{
    public interface IHPView
    {
        void SetHPValue(float ratio);
        void SetHPValue(float current, float max);
    }
}
