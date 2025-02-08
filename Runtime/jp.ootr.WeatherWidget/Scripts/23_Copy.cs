using TMPro;
using UnityEngine;

namespace jp.ootr.WeatherWidget
{
    public class Copy : Icon
    {
        [SerializeField] private TextMeshProUGUI regionText;
        [SerializeField] private TextMeshProUGUI copyText;
        
        protected override void OnWeatherLoadSuccess(WeatherData data)
        {
            base.OnWeatherLoadSuccess(data);
            if (
                !data.GetPublishingOffice(out var office) ||
                !data.GetReportDateTime(out var dateTime) ||
                !data.GetRegion(out var region)
            )
                return;
            var locale = data.GetLocale();
            var hideLocation = data.GetHideLocation();
            regionText.text = hideLocation ? GetText("weather", locale) : string.Format(GetText("region", locale), region);
            copyText.text = string.Format(GetText("copy", locale), office, dateTime);
        }
    }
}
