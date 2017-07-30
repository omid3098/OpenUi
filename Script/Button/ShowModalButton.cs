using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class ShowModalButton : ODButton
    {
        [SerializeField] private ModalType modalType;
        override protected void Pressed()
        {
            base.Pressed();
            UiManager.instance.ShowModal(modalType);
        }
    }
}