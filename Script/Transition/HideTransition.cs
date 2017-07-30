using System;
using Prime31.ZestKit;

namespace OpenUi.Transition
{
    public class HideTransition : BaseTransition
    {
        protected override void Fade(float _duration, Action _onPlayCallback, EaseType _easeType)
        {
            transform.FadeOut(_duration, _easeType, _onPlayCallback, true);
        }

        protected override void Scale(float _duration, Action _onPlayCallback, EaseType _easeType)
        {
            transform.ScaleOut(_duration, _easeType, _onPlayCallback, true);
        }

        protected override void ScaleX(float _duration, Action _onPlayCallback, EaseType _easeType)
        {
            transform.ScaleOutX(_duration, _easeType, _onPlayCallback, true);
        }

        protected override void ScaleY(float _duration, Action _onPlayCallback, EaseType _easeType)
        {
            transform.ScaleOutY(_duration, _easeType, _onPlayCallback, true);
        }

        internal override void Slide(float _duration, Action _onPlayCallback, EaseType _easeType, slideDirection _direction)
        {
            transform.SlideOut(_duration,_easeType,_onPlayCallback,true,false,_direction);
        }
    }
}