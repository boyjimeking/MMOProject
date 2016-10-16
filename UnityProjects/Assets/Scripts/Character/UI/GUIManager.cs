using UnityEngine;
using System.Collections;

namespace YCG.UI
{
    public class GUIManager : SingletonBehaviour<GUIManager>
    {
        IHPView _hpView;

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
