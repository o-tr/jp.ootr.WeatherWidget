using jp.ootr.common;
using UnityEditor;

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

            EditorGUILayout.LabelField("Forecast Count");
            script.forecastCount = (int)EditorGUILayout.Slider(script.forecastCount, 3, 7);

            if (!EditorGUI.EndChangeCheck()) return;
            EditorUtility.SetDirty(script);
        }
    }
}