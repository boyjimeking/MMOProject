using UnityEngine;
using UnityEngine.UI;

namespace YCG.UI
{
    public class GUIManager : SingletonBehaviour<GUIManager>
    {
        IHPView _hpView;
        [SerializeField]
        Button _charaButton, _weaponButton, petButton, skillButton;

        protected override void OnAwake()
        {
            base.OnAwake();
            _hpView = GetComponentInChildren<IHPView>();
        }

        public void SetHPView(int HP, int MaxHP)
        {
            _hpView.SetHPValue(HP, MaxHP);
        }
    }
}
