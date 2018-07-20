using System;
using System.Collections.Generic;
using OpenUi;
using UnityEngine;
using UnityEngine.Assertions;

namespace OpenUi
{
    public class Window<T, TMod> : ViewBase
        where T : struct, IConvertible
        where TMod : struct, IConvertible
    {
        #region Fields
        public T windowType;
        public List<Modal<TMod>> modalList { get; private set; }

        // assigned modals from unity inspector
        [SerializeField] public List<GameObject> staticModals;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            modalList = new List<Modal<TMod>>();
            foreach (var modal in staticModals)
            {
                var _staticModal = Instantiate(modal);
                _staticModal.transform.SetParent(transform, false);
                _staticModal.SetActive(true);
                var _m = _staticModal.GetComponent<Modal<TMod>>();
                Assert.IsNotNull(_m, _staticModal.name + " - static modal does not have modal component on this window: " + gameObject.name);
                AddModal(_m);
            }
        }
        public void Hide(Action OnComplete)
        {
            if (hideTransition != null) hideTransition.Play(_onPlayCallback: OnComplete);
            else Debug.LogError("There is no hideTransition component on this window.");
        }

        public void Show(Action OnComplete)
        {
            if (showTransition != null) showTransition.Play(_onPlayCallback: OnComplete);
            else Debug.LogError("There is no showTransition component on this window.");
        }

        public void AddModal(Modal<TMod> modal)
        {
            modalList.Add(modal);
        }

        public Modal<TMod> GetModal(TMod modalType)
        {
            var modal = modalList.Find(x => EqualityComparer<TMod>.Default.Equals(x.modalType, modalType));
            return modal;
        }

        public void RemoveModal(Modal<TMod> modal)
        {
            modalList.Remove(modal);
        }

        public List<Modal<TMod>> GetActiveModals()
        {
            List<Modal<TMod>> _tmpModals = new List<Modal<TMod>>();
            foreach (var modal in modalList)
            {
                if (modal.gameObject.activeInHierarchy)
                {
                    _tmpModals.Add(modal);
                }
            }
            return _tmpModals;
        }
        #endregion
    }
}