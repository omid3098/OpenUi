using System.Collections.Generic;
using OpenUi;
using UnityEngine;
namespace OpenUi
{
    public class UiManager : MonoBehaviour
    {
        #region Properties
        private static UiManager _instance;
        public static UiManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<UiManager>();
                    if (_instance == null)
                    {
                        var t = new GameObject("ui-manager");
                        _instance = t.AddComponent<UiManager>();
                    }
                }
                return _instance;
            }
        }

        public Canvas canvas
        {
            get
            {
                if (_canvas == null)
                {
                    var t = Resources.Load<Canvas>(UiManagerSetting.canvasPath);
                    _canvas = GameObject.Instantiate(t);
                    _canvas.transform.SetParent(transform, false);
                }
                return _canvas;
            }
        }
        private Canvas _canvas;
        #endregion

        #region Fields
        [SerializeField] private WindowType initialMenu;
        private List<Window> windowPrefabs;
        private List<Window> windowList;
        private List<Modal> modalPrefabs;
        private List<FormButton> formButtonPrefabs;
        private Window currentWindow;
        #endregion

        #region Methods
        void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
            LoadService();
            ChangeWindow(initialMenu);
        }

        void LoadService()
        {
            windowPrefabs = new List<Window>();
            windowList = new List<Window>();
            modalPrefabs = new List<Modal>();
            formButtonPrefabs = new List<FormButton>();
            windowPrefabs.AddRange(Resources.LoadAll<Window>(UiManagerSetting.windowPath));
            modalPrefabs.AddRange(Resources.LoadAll<Modal>(UiManagerSetting.modalPath));
            formButtonPrefabs.AddRange(Resources.LoadAll<FormButton>(UiManagerSetting.buttonPath));
        }

        public void ChangeWindow(WindowType windowType)
        {
            if (currentWindow != null) currentWindow.Hide();
            Window window;
            window = windowList.Find(x => x.windowType == windowType);
            // if first time showing window
            if (window == null)
            {
                Window windowPrefab = windowPrefabs.Find(x => x.windowType == windowType);
                if (windowPrefab != null)
                {
                    window = GameObject.Instantiate(windowPrefab);
                    window.transform.SetParent(canvas.transform, false);
                    // window.transform.SetAsLastSibling();
                    windowList.Add(window);
                }
                else
                {
                    Debug.LogError("Could not find window with " + windowType + " type in Resources/" + UiManagerSetting.windowPath + " path.");
                    return;
                }
            }
            currentWindow = window;
            window.Show();
        }

        public void ShowModal(ModalType modalType)
        {
            Modal modal;
            modal = currentWindow.GetModal(modalType);
            // if first time showing modal
            if (modal == null)
            {
                Modal modalPrefab = modalPrefabs.Find(x => x.modalType == modalType);
                if (modalPrefab != null)
                {
                    modal = GameObject.Instantiate(modalPrefab);
                    modal.transform.SetParent(currentWindow.transform, false);
                    // modal.transform.SetAsLastSibling();
                }
                else
                {
                    Debug.LogError("Could not find modal with " + modalType + " type in Resources/" + UiManagerSetting.modalPath + " path.");
                    return;
                }
            }
            currentWindow.AddModal(modal);
            modal.Show();
        }

        public void HideModal(ModalType modalType)
        {
            Modal modal;
            modal = currentWindow.GetModal(modalType);
            if (modal != null)
            {
                modal.Hide();
                currentWindow.RemoveModal(modal);
            }
        }

        internal FormButton GetButtonPrefab(FormButtonTypes formButtonType)
        {
            FormButton btnPrefab = formButtonPrefabs.Find(x => x.formButtonType == formButtonType);
            return btnPrefab;
        }
        #endregion
    }
}