using UnityEngine;
using UnityEngine.UI;

namespace YCG.UI
{
    public class SimpleHPView : MonoBehaviour, IHPView
    {
        [SerializeField]
        Image _hpBar;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

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
