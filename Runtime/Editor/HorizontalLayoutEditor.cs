using jp.ootr.common;
using UnityEditor;
using UnityEngine;

namespace jp.ootr.WeatherWidget.Editor
{
    [CustomEditor(typeof(HorizontalLayout))]
    public class HorizontalLayoutEditor : UnityEditor.Editor
    {
        private bool _debug;
        public override void OnInspectorGUI()
        {
            var script = (HorizontalLayout)target;
            
            _debug = EditorGUILayout.ToggleLeft("Debug", _debug);
            if (_debug)
            {
                base.OnInspectorGUI();
                return;
            }
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.LabelField("WeatherWidget", EditorStyle.UiTitle);

            EditorGUILayout.Space();

            script.forecastCount = (int)EditorGUILayout.Slider("Forecast Count",script.forecastCount, 3, 7);

            EditorGUILayout.Space();
            
            script.splashImage.sprite = (Sprite)EditorGUILayout.ObjectField("SplashImage", script.splashImage.sprite, typeof(Sprite), false);
            
            if (!EditorGUI.EndChangeCheck()) return;
            EditorUtility.SetDirty(script);
        }
    }
}