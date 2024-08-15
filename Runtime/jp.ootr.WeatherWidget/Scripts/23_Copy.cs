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
            if(
                !data.GetPublishingOffice(out var office) ||
                !data.GetReportDateTime(out var dateTime) ||
                !data.GetRegion(out var region)
            )
            {
                return;
            }
            regionText.text = $"{region} の天気";
            copyText.text = $"{office} {dateTime} 発表";
        }
    }
}