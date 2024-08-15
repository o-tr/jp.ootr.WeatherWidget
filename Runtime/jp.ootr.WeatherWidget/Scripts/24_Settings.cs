using UnityEngine;

namespace jp.ootr.WeatherWidget
{
    public class Settings : Copy {
        private readonly int _animatorShow = Animator.StringToHash("Settings");
        private bool _isShown = false;
        
        public void ToggleSettings()
        {
            _isShown = !_isShown;
            animator.SetBool(_animatorShow, _isShown);
        }
    }
}