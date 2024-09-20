using jp.ootr.common;
using jp.ootr.common.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace jp.ootr.WeatherWidget.Editor
{
    public class WidgetEditor : BaseEditor 
    {
        private SerializedProperty _forecastCount;
        private SerializedProperty _splashImageTexture;
        
        public override void OnEnable()
        {
            base.OnEnable();
            _forecastCount = serializedObject.FindProperty("forecastCount");
        }

        protected override VisualElement GetLayout()
        {
            var root = new VisualElement();
            
            var forecastCountField = new PropertyField(_forecastCount);
            forecastCountField.Bind(serializedObject);
            root.Add(forecastCountField);
            
            return root;
        }

        protected override string GetScriptName()
        {
            return "WeatherWidget";
        }
    }
}
