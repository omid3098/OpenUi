using OpenUi;
using UnityEngine;

namespace OpenUi.Button
{
    public class HideModalButton : ODButton
    {
        [SerializeField] private SampleModalType modalType;
        override protected void Pressed()
        {
            base.Pressed();
            UiManager<SampleWindowType, SampleModalType>.instance.HideModal(modalType);
        }
    }
}