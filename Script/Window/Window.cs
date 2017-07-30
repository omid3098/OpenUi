using System.Collections.Generic;
using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class Window : ViewBase
    {
        #region Fields
        public WindowType windowType;
        private List<Modal> modalList;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            modalList = new List<Modal>();
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

        public void AddModal(Modal modal)
        {
            modalList.Add(modal);
        }

        public Modal GetModal(ModalType modalType)
        {
            var modal = modalList.Find(x => x.modalType == modalType);
            return modal;
        }

        internal void RemoveModal(Modal modal)
        {
            modalList.Remove(modal);
        }
        #endregion
    }
}