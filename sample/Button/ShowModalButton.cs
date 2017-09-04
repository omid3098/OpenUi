using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class ShowModalButton : ODButton
    {
        [SerializeField] private SampleModalType modalType;
        private UiManager<SampleWindowType, SampleModalType> uiManager;
        override protected void Pressed()
        {
            base.Pressed();
            // if (uiManager == null) uiManager = FindObjectOfType<UiManager<SampleWindowType, SampleModalType>>();
            if (uiManager != null) uiManager.ShowModal(modalType);
            else Debug.Log("Uimanager is not set");
        }
    }
}