using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class ChangeWindowButton : ODButton
    {
        [SerializeField] private SampleWindowType windowType;
        override protected void Pressed()
        {
            base.Pressed();
            Debug.Log("Showing window: " + windowType);
            UiManager<SampleWindowType, SampleModalType>.instance.ChangeWindow(windowType);
        }
    }
}