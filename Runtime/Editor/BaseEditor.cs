using jp.ootr.common;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace jp.ootr.WeatherWidget.Editor
{
    public class BaseEditor : UnityEditor.Editor
    {
        private bool _debug;
        private SerializedProperty _forecastCount;
        private SerializedProperty _splashImageTexture;
        
        private void OnEnable()
        {
            _forecastCount = serializedObject.FindProperty("forecastCount");
        }

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
            serializedObject.Update();
            EditorGUILayout.LabelField("WeatherWidget", EditorStyle.UiTitle);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_forecastCount, new GUIContent("Forecast Count"));

            EditorGUILayout.Space();

            if (script.splashImage != null)
            {
                EditorGUILayout.PropertyField(_splashImageTexture, new GUIContent("Splash Image"));
                var texture = (Sprite)_splashImageTexture.objectReferenceValue;
                if (texture != script.splashImage.sprite)
                {
                    var splashImageProp = serializedObject.FindProperty("splashImage");
                    var splashImage = (Image)splashImageProp.objectReferenceValue;
                    var soImage = new SerializedObject(splashImage);
                    soImage.Update();
                    soImage.FindProperty("m_Texture").objectReferenceValue = texture;
                    soImage.ApplyModifiedProperties();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
