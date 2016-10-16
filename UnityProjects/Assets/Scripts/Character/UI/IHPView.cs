using UnityEngine;
using System.Collections;

namespace YCG.UI
{
    public interface IHPView : IUIView
    {
        void SetHPValue(float ratio);
        void SetHPValue(float current, float max);
    }
}
