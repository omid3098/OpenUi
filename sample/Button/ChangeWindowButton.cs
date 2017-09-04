using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class ChangeWindowButton : ODButton
    {
        [SerializeField] private SampleWindowType windowType;
        private UiManager<SampleWindowType, SampleModalType> uiManager;
        override protected void Pressed()
        {
            base.Pressed();
            Debug.Log("Showing window: " + windowType);
            // if (uiManager == null) uiManager = FindObjectOfType<UiManager<SampleWindowType, SampleModalType>>();
            if (uiManager != null) uiManager.ChangeWindow(windowType);
            else Debug.Log("Uimanager is not set");
        }
    }
}