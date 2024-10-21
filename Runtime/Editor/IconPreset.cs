using UnityEngine;

namespace jp.ootr.WeatherWidget.Editor
{
    [CreateAssetMenu(fileName = "IconPreset", menuName = "ootr/WeatherWidget/IconPreset")]
    public class IconPreset : ScriptableObject
    {
        public string[] iconNames;
        public Sprite[] icons;
    }
}
