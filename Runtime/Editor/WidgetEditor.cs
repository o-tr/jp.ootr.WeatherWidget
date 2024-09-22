using jp.ootr.common.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
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
            
            root.Add(GetForecastCount());
            
            return root;
        }

        private VisualElement GetForecastCount()
        {
            var root = new VisualElement();
            
            var forecastCount = new PropertyField(_forecastCount);
            forecastCount.Bind(serializedObject);
            root.Add(forecastCount);

            var openEditor = new Button
            {
                text = "Open Utility",
            };
            openEditor.clicked += () =>
            {
                WeatherWidgetUtils.ShowWindowWithTarget((WeatherWidgetBase)target);
            };
            root.Add(openEditor);
            
            return root;
        }

        protected override string GetScriptName()
        {
            return "WeatherWidget";
        }
    }
}
