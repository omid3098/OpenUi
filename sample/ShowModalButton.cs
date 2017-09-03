using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class ShowModalButton : ODButton
    {
        [SerializeField] private SampleModalType modalType;
        override protected void Pressed()
        {
            base.Pressed();
            UiManager<SampleWindowType, SampleModalType>.instance.ShowModal(modalType);
        }
    }
}