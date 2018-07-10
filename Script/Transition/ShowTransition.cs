using System;
using DG.Tweening;

namespace OpenUi.Transition
{
    public class ShowTransition : BaseTransition
    {
        protected override void Fade(float _duration, Action _onPlayCallback, Ease _easeType)
        {
            transform.FadeIn(_duration, _easeType, _onPlayCallback);
        }
        protected override void Scale(float _duration, Action _onPlayCallback, Ease _easeType)
        {
            transform.ScaleIn(_duration, _easeType, _onPlayCallback);
        }

        protected override void ScaleX(float _duration, Action _onPlayCallback, Ease _easeType)
        {
            transform.ScaleInX(_duration, _easeType, _onPlayCallback);
        }

        protected override void ScaleY(float _duration, Action _onPlayCallback, Ease _easeType)
        {
            transform.ScaleInY(_duration, _easeType, _onPlayCallback);
        }

        internal override void Slide(float _duration, Action _onPlayCallback, Ease _easeType, slideDirection _direction)
        {
            transform.SlideIn(_duration, _easeType, _onPlayCallback, false, false, _direction);
        }
    }
}