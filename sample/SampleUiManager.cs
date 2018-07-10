using OpenUi;
using UnityEngine;

public class SampleUiManager : MonoBehaviour
{
    public UiManager<SampleWindowType, SampleModalType> uiManager { get; private set; }

    private void Awake()
    {
        uiManager = new UiManager<SampleWindowType, SampleModalType>();
        uiManager.ChangeWindow(SampleWindowType.MainMenu);
    }
}