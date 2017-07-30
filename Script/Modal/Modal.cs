using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class Modal : ViewBase
    {
        [SerializeField] private bool bshowCloseButton = true;
        public ModalType modalType;

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            if (bshowCloseButton) ShowCloseButton();
        }

        private void ShowCloseButton()
        {
            var t = GameObject.Instantiate(UiManager.instance.GetButtonPrefab(FormButtonTypes.close));
            t.transform.SetParent(transform, false);
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