using jp.ootr.common;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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

            script.forecastCount = (int)EditorGUILayout.Slider("Forecast Count", script.forecastCount, 3, 7);

            EditorGUILayout.Space();

            if (EditorGUI.EndChangeCheck()) EditorUtility.SetDirty(script);
            if (script.splashImage != null)
            {
                var texture = (Sprite)EditorGUILayout.ObjectField("Splash Image",
                    script.splashImage.sprite, typeof(Sprite), false);
                if (texture != script.splashImage.sprite)
                {
                    var splashImageProp = serializedObject.FindProperty("splashImage");
                    var splashImage = (Image)splashImageProp.objectReferenceValue;
                    var soImage = new SerializedObject(splashImage);
                    soImage.FindProperty("m_Texture").objectReferenceValue = texture;
                    soImage.ApplyModifiedProperties();
                }
            }
        }
    }
}
