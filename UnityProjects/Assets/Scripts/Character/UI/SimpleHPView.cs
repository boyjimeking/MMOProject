using UnityEngine;
using System.Collections;

namespace YCG
{
    public class SimpleHPView : MonoBehaviour, IHPView
    {
        [SerializeField]
        SpriteRenderer _hpBar;

        public void SetHPValue(float ratio)
        {
            SetHPBar(ratio);
        }

        public void SetHPValue(float current, float max)
        {
            SetHPBar(Mathf.Clamp(current / max, 0, 1));
        }

        private void SetHPBar(float ratio)
        {
            _hpBar.transform.SetLocalScaleX(ratio);
        }
    }
}
