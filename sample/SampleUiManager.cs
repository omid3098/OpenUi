using OpenUi;
using UnityEngine;

public class SampleUiManager : MonoBehaviour
{
    class SampleGameUiSetting : UiManagerSetting
    {
        public override string canvasPath { get { return "ui/ui-canvas"; } }
        public override string windowPath { get { return "ui/window"; } }
        public override string modalPath { get { return "ui/modal"; } }
        public override string buttonPath { get { return "ui/button"; } }
    }
    public UiManager<SampleWindowType, SampleModalType> uiManager { get; private set; }

    private void Awake()
    {
        UiManagerSetting setting = new SampleGameUiSetting();
        uiManager = new UiManager<SampleWindowType, SampleModalType>(setting);
        uiManager.ChangeWindow(SampleWindowType.MainMenu);
    }
}