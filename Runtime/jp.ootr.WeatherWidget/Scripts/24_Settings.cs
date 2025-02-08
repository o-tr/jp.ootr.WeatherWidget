using TMPro;
using UnityEngine;

namespace jp.ootr.WeatherWidget
{
    public class Settings : Copy
    {
        [SerializeField] private TextMeshProUGUI _settingsTitle;
        private readonly int _animatorShow = Animator.StringToHash("Settings");
        private bool _isShown;

        public void ToggleSettings()
        {
            _isShown = !_isShown;
            animator.SetBool(_animatorShow, _isShown);
        }

        protected override void OnWeatherLoadSuccess(WeatherData data)
        {
            base.OnWeatherLoadSuccess(data);
            _settingsTitle.text = GetText("settings", data.GetLocale());
        }
    }
}
