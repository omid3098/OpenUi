using System;
using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class Modal<T> : ViewBase
        where T : struct, IConvertible
    {
        public T modalType;

        #region Methods
        protected override void Awake()
        {
            base.Awake();
        }

        public void Hide()
        {
            if (hideTransition != null) hideTransition.Play();
            else Debug.LogError("There is no hideTransition component on this window.");
        }

        public void Show()
        {
            if (showTransition != null) showTransition.Play();
            else Debug.LogError("There is no showTransition component on this window.");
        }
        #endregion
    }
}