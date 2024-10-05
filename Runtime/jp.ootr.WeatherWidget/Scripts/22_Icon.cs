using jp.ootr.common;
using UnityEngine;

namespace jp.ootr.WeatherWidget
{
    public class Icon : Logic
    {
        [SerializeField] private Sprite[] icons;
        [SerializeField] private string[] iconNames;

        protected Sprite GetIconByName(string iconName)
        {
            if (iconNames.Has(iconName, out var index)) return icons[index];
            return icons.Length > 0 ? icons[0] : null;
        }
    }
}
