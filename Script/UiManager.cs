using System;
using System.Collections.Generic;
using OpenUi;
using UnityEngine;
namespace OpenUi
{
    public class UiManager<TWin, TMod>
        where TWin : struct, IConvertible
        where TMod : struct, IConvertible
    {
        #region Properties
        // private static UiManager<TWin, TMod> _instance;
        // public static UiManager<TWin, TMod> instance
        // {
        //     get
        //     {
        //         if (_instance == null)
        //         {
        //             _instance = GameObject.FindObjectOfType<UiManager<TWin, TMod>>();
        //             if (_instance == null)
        //             {
        //                 var t = new GameObject("ui-manager");
        //                 _instance = t.AddComponent<UiManager<TWin, TMod>>();
        //             }
        //         }
        //         return _instance;
        //     }
        // }

        public Canvas canvas
        {
            get
            {
                if (_canvas == null)
                {
                    var t = Resources.Load<Canvas>(_setting.canvasPath);
                    _canvas = GameObject.Instantiate(t);
                    // _canvas.transform.SetParent(transform, false);
                }
                return _canvas;
            }
        }
        private Canvas _canvas;
        #endregion

        #region Fields
        [SerializeField] private TWin initialMenu;
        private List<Window<TWin, TMod>> windowPrefabs;
        private List<Window<TWin, TMod>> windowList;
        private List<Modal<TMod>> modalPrefabs;
        private Window<TWin, TMod> currentWindow;
        private UiManagerSetting _setting;

        public UiManager(UiManagerSetting setting)
        {
            _setting = setting;
            LoadService();
        }

        #endregion

        #region Methods

        void LoadService()
        {
            windowPrefabs = new List<Window<TWin, TMod>>();
            windowList = new List<Window<TWin, TMod>>();
            modalPrefabs = new List<Modal<TMod>>();
            // windowPrefabs.AddRange(Resources.LoadAll<Window<TWin, TMod>>(_setting.windowPath));
            // modalPrefabs.AddRange(Resources.LoadAll<Modal<TMod>>(_setting.modalPath));
        }

        public Window<TWin, TMod> ChangeWindow(TWin windowType, Action OnComplete = null)
        {
            if (currentWindow != null && EqualityComparer<TWin>.Default.Equals(currentWindow.windowType, windowType))
            {
                if (OnComplete != null) OnComplete.Invoke();
                // Debug.LogError("Returning because of same current windowType");
                return currentWindow;
            }
            if (currentWindow != null) currentWindow.Hide(null);
            Window<TWin, TMod> window;
            window = windowList.Find(x => EqualityComparer<TWin>.Default.Equals(x.windowType, windowType));

            // if first time showing window
            if (window == null)
            {
                Window<TWin, TMod> windowPrefab = windowPrefabs.Find(x => EqualityComparer<TWin>.Default.Equals(x.windowType, windowType));
                if (windowPrefab == null) windowPrefab = Resources.Load<Window<TWin, TMod>>(_setting.windowPath + "/" + windowType.ToString());
                if (windowPrefab != null)
                {
                    if (windowPrefab.windowType.ToString() != windowType.ToString()) Debug.LogWarning(_setting.windowPath + "/" + windowType.ToString() + "--> This resource pretends to be a " + windowType + " window, but its component type missmatches");
                    windowPrefabs.Add(windowPrefab);
                    window = GameObject.Instantiate(windowPrefab);
                    window.transform.SetParent(canvas.transform, false);
                    // window.transform.SetAsLastSibling();
                    windowList.Add(window);
                }
                else
                {
                    Debug.LogError("Could not find window with " + windowType + " name in Resources/" + _setting.windowPath + " path.");
                    return null;
                }
            }
            currentWindow = window;
            window.Show(OnComplete);
            return currentWindow;
        }

        public Modal<TMod> ShowModal(TMod modalType)
        {
            return ShowModal(modalType, null);
        }

        public Modal<TMod> ShowModal(TMod modalType, Action OnComplete)
        {
            Modal<TMod> modal;
            modal = currentWindow.GetModal(modalType);
            // if first time showing modal
            if (modal == null)
            {
                Modal<TMod> modalPrefab = modalPrefabs.Find(x => EqualityComparer<TMod>.Default.Equals(x.modalType, modalType));
                if (modalPrefab == null) modalPrefab = Resources.Load<Modal<TMod>>(_setting.modalPath + "/" + modalType.ToString());
                if (modalPrefab != null)
                {
                    if (modalPrefab.modalType.ToString() != modalType.ToString()) Debug.LogWarning(_setting.modalPath + "/" + modalType.ToString() + "--> This resource pretends to be a " + modalType + " modal, but its component type missmatches");
                    modalPrefabs.Add(modalPrefab);
                    modal = GameObject.Instantiate(modalPrefab);
                    modal.transform.SetParent(currentWindow.transform, false);
                    // modal.transform.SetAsLastSibling();
                }
                else
                {
                    Debug.LogError("Could not find modal with " + modalType + " name in Resources/" + _setting.modalPath + " path.");
                    return null;
                }
            }
            else
            {
                // if modal is already active, return without showing again.
                // because we only can have one active modal with each type.
                if (modal.gameObject.activeInHierarchy)
                {
                    if (OnComplete != null) OnComplete.Invoke();
                    return modal;
                }
            }
            currentWindow.AddModal(modal);
            modal.Show(OnComplete);
            return modal;
        }

        public Modal<TMod> HideModal(TMod modalType)
        {
            Modal<TMod> modal;
            modal = currentWindow.GetModal(modalType);
            if (modal != null)
            {
                modal.Hide();
                // currentWindow.RemoveModal(modal);
            }
            return modal;
        }

        #endregion
    }
}