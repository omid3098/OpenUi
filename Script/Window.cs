using System;
using System.Collections.Generic;
using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class Window<T, TMod> : ViewBase
        where T : struct, IConvertible
        where TMod : struct, IConvertible
    {
        #region Fields
        public T windowType;
        private List<Modal<TMod>> modalList;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            modalList = new List<Modal<TMod>>();
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

        public void AddModal(Modal<TMod> modal)
        {
            modalList.Add(modal);
        }

        public Modal<TMod> GetModal(TMod modalType)
        {
            var modal = modalList.Find(x => EqualityComparer<TMod>.Default.Equals(x.modalType, modalType));
            return modal;
        }

        internal void RemoveModal(Modal<TMod> modal)
        {
            modalList.Remove(modal);
        }
        #endregion
    }
}