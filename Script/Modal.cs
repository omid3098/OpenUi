using System;
using OpenUi;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OpenUi
{
    [System.Serializable]
    public class Modal<T> : ViewBase, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    where T : struct, IConvertible
    {
        public T modalType;
        private RectTransform _rectTransform;
        public bool _hideIfClickOutside;
        public bool hideWithBackButton = false;
        private bool mouseOver;

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Hide(Action onComplete = null)
        {
            if (hideTransition != null) hideTransition.Play(_onPlayCallback: onComplete);
            else Debug.LogError("There is no hideTransition component on this window.");
        }

        public void Show(Action onComplete)
        {
            if (showTransition != null) showTransition.Play(_onPlayCallback: onComplete);
            else Debug.LogError("There is no showTransition component on this window.");
        }
        public void Show()
        {
            Show(null);
        }

        private void HideIfClickedOutside()
        {
            if (Input.GetMouseButtonDown(0) && mouseOver == false)
            {
                Hide();
                return;
            }
            // if (Input.GetMouseButtonDown (0) &&
            //     !RectTransformUtility.RectangleContainsScreenPoint (
            //         _rectTransform,
            //         Input.mousePosition,
            //         Camera.main))
            if (Input.GetMouseButtonDown(0) &&
                !_rectTransform.rect.Contains(Input.mousePosition))
            {
                Debug.Log("Clicked outside, lets hide " + gameObject.name);
                Hide();
                return;
            }
        }

        void Update()
        {
            if (_hideIfClickOutside)
            {
                HideIfClickedOutside();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mouseOver = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouseOver = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_hideIfClickOutside)
                if (!_rectTransform.rect.Contains(eventData.position))
                {
                    Debug.Log("Clicked outside, lets hide " + gameObject.name);
                    Hide();
                    return;
                }
        }
        #endregion
    }
}