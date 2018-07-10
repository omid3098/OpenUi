using System;
using DG.Tweening;
using UnityEngine;

namespace OpenUi.Transition
{
    public enum slideDirection
    {
        left,
        right,
        up,
        down,
    }
    public abstract class BaseTransition : MonoBehaviour
    {
        public float duration = 0.2f;
        public TransitionType transitionType = TransitionType.fade;
        public Ease easeType;
        private Action onPlayCallback;
        public void Play(float _duration = -1f, TransitionType _transitionType = TransitionType.none, Action _onPlayCallback = null, Ease _easeType = Ease.Linear)
        {
            if (_duration == -1f) _duration = duration;
            if (_transitionType == TransitionType.none) _transitionType = transitionType;
            if (_easeType == Ease.Linear) _easeType = easeType;
            switch (_transitionType)
            {
                case TransitionType.none:
                    gameObject.SetActive(true);
                    if (_onPlayCallback != null) _onPlayCallback.Invoke();
                    break;
                case TransitionType.fade:
                    Fade(_duration, _onPlayCallback, _easeType);
                    break;
                case TransitionType.scale:
                    Scale(_duration, _onPlayCallback, _easeType);
                    break;
                case TransitionType.scaleX:
                    ScaleX(_duration, _onPlayCallback, _easeType);
                    break;
                case TransitionType.scaleY:
                    ScaleY(_duration, _onPlayCallback, _easeType);
                    break;
                case TransitionType.slideLeft:
                    Slide(_duration, _onPlayCallback, _easeType, slideDirection.left);
                    break;
                case TransitionType.slideRight:
                    Slide(_duration, _onPlayCallback, _easeType, slideDirection.right);
                    break;
                case TransitionType.slideUp:
                    Slide(_duration, _onPlayCallback, _easeType, slideDirection.up);
                    break;
                case TransitionType.slideDown:
                    Slide(_duration, _onPlayCallback, _easeType, slideDirection.down);
                    break;
            }
        }

        protected abstract void Fade(float _duration, Action _onPlayCallback, Ease _easeType);
        protected abstract void Scale(float _duration, Action _onPlayCallback, Ease _easeType);
        protected abstract void ScaleX(float _duration, Action _onPlayCallback, Ease _easeType);
        protected abstract void ScaleY(float _duration, Action _onPlayCallback, Ease _easeType);
        internal abstract void Slide(float duration, Action onPlayCallback, Ease easeType, slideDirection direction);
    }
}