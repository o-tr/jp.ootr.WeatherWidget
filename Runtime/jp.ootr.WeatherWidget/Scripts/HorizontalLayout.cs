using jp.ootr.common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace jp.ootr.WeatherWidget
{
    public class HorizontalLayout : Copy
    {
        [SerializeField] private Transform rootTransform;
        [SerializeField] private GameObject baseObject;
        [SerializeField] private TextMeshProUGUI dateText;
        [SerializeField] private Image forecastImage;
        [SerializeField] private TextMeshProUGUI forecastText;
        [SerializeField] private TextMeshProUGUI tempText;
        [SerializeField] private TextMeshProUGUI popText;
        [SerializeField] private TextMeshProUGUI overviewText;
        [SerializeField] public int forecastCount;

        protected override void OnWeatherLoadSuccess(WeatherData data)
        {
            base.OnWeatherLoadSuccess(data);
            var count = Mathf.Min(forecastCount, data.GetWeatherSize(out var size) ? size : 0);
            for (var i = 0; i < count; i++)
            {
                if (!data.GetWeather(i, out var date, out var tempMin, out var tempMax, out var pop, out var icon, out var weather))
                {
                    continue;
                }
                dateText.text = date;
                forecastImage.sprite = GetIconByName(icon);
                forecastText.text = weather;
                tempText.text = $"{tempMin}/{tempMax}";
                popText.text = $"{pop}";
                var obj = Instantiate(baseObject, rootTransform);
                obj.SetActive(true);
            }
            rootTransform.ToFillChildrenHorizontal(8,8);
            data.GetOverview(out var overview);
            overviewText.text = overview;
        }
    }
}