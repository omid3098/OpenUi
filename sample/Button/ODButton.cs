namespace OpenUi
{
    public class ODButton : ViewBase
    {
        UnityEngine.UI.Button button;
        override protected void Awake()
        {
            base.Awake();
            button = GetComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(Pressed);
        }

        protected virtual void Pressed()
        {
            // Debug.Log("Button Pressed");
        }
    }
}