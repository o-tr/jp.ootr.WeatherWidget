using VRC.SDK3.Data;

namespace jp.ootr.WeatherWidget
{
    public class WeatherData : DataDictionary
    {
    }

    public static class _WeatherUtils
    {
        public static bool GetWeatherSize(this WeatherData data, out int size)
        {
            size = 0;
            if (!data.TryGetValue("weather", out var weatherList)) return false;
            size = weatherList.DataList.Count;
            return true;
        }

        public static bool GetWeather(this WeatherData data, int index, out string date, out string tempMin,
            out string tempMax, out string pop, out string icon, out string weather)
        {
            date = pop = icon = weather = tempMin = tempMax = "";
            if (
                !data.TryGetValue("weather", out var weatherList) ||
                !weatherList.DataList.TryGetValue(index, out var weatherData) ||
                !weatherData.DataDictionary.TryGetValue("date", out var dateToken) ||
                !weatherData.DataDictionary.TryGetValue("tempMin", out var tempMinToken) ||
                !weatherData.DataDictionary.TryGetValue("tempMax", out var tempMaxToken) ||
                !weatherData.DataDictionary.TryGetValue("pop", out var popToken) ||
                !weatherData.DataDictionary.TryGetValue("icon", out var iconToken) ||
                !weatherData.DataDictionary.TryGetValue("weather", out var weatherToken)
            )
                return false;
            date = dateToken.String;
            tempMin = tempMinToken.String;
            tempMax = tempMaxToken.String;
            pop = popToken.String;
            icon = iconToken.String;
            weather = weatherToken.String;
            return true;
        }

        public static bool GetPublishingOffice(this WeatherData data, out string office)
        {
            office = "";
            if (!data.TryGetValue("publishingOffice", out var officeToken)) return false;
            office = officeToken.String;
            return true;
        }

        public static bool GetReportDateTime(this WeatherData data, out string dateTime)
        {
            dateTime = "";
            if (!data.TryGetValue("reportDatetime", out var dateTimeToken)) return false;
            dateTime = dateTimeToken.String;
            return true;
        }

        public static bool GetRegion(this WeatherData data, out string region)
        {
            region = "";
            if (!data.TryGetValue("region", out var regionToken)) return false;
            region = regionToken.String;
            return true;
        }

        public static bool GetOverview(this WeatherData data, out string overview)
        {
            overview = "";
            if (!data.TryGetValue("overview", out var overviewToken)) return false;
            overview = overviewToken.String;
            return true;
        }
    }
}
