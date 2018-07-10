namespace OpenUi
{
    public class ODButton : ViewBase
    {
        UnityEngine.UI.Button button;
        protected static UiManager<SampleWindowType, SampleModalType> uiManager;
        override protected void Awake()
        {
            base.Awake();
            uiManager = FindObjectOfType<SampleUiManager>().uiManager;
            button = GetComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(Pressed);
        }

        protected virtual void Pressed()
        {
            // Debug.Log("Button Pressed");
        }
    }
}