using OpenUi;
using UnityEngine;

namespace OpenUi.Button
{
    public class HideModalButton : ODButton
    {
        [SerializeField] private ModalType modalType;
        override protected void Pressed()
        {
            base.Pressed();
            UiManager.instance.HideModal(modalType);
        }
    }
}