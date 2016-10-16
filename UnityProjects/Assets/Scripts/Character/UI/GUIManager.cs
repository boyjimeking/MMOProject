using System;
using UnityEngine;
using UnityEngine.UI;

namespace YCG.UI
{
    public class GUIManager : SingletonBehaviour<GUIManager>
    {
        IHPView _hpView;
        public Action SkillAction { get; set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            _hpView = GetComponentInChildren<IHPView>();
        }

        public void SetHPView(int HP, int MaxHP)
        {
            _hpView.SetHPValue(HP, MaxHP);
        }

        public void OnInvokeSkill()
        {
            if (SkillAction != null)
                SkillAction.Invoke();
        }
    }
}
