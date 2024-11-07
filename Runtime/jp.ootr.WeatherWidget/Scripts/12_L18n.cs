using jp.ootr.common;
using UnityEngine;

namespace jp.ootr.WeatherWidget
{
    
    public class L18n : BaseClass {
        [SerializeField] private string[] l18nKeys;
        [SerializeField] private string[] l18nValues;
        
        protected string GetText(string name, string lang)
        {
            var key = $"{lang}.{name}";
            if (l18nKeys.Has(key, out var index))
            {
                return l18nValues[index];
            }
            var defaultKey = $"EN.{name}";
            if (l18nKeys.Has(defaultKey, out var defaultIndex))
            {
                return l18nValues[defaultIndex];
            }
            return name;
        }
    }
}
