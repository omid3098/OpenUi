using OpenUi;
using UnityEngine;

namespace OpenUi
{
    public class ChangeWindowButton : ODButton
    {
        [SerializeField] private WindowType windowType;
        override protected void Pressed()
        {
            base.Pressed();
            Debug.Log("Showing window: " + windowType);
            UiManager.instance.ChangeWindow(windowType);
        }
    }
}