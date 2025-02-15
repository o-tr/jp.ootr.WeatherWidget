﻿using jp.ootr.common.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using Image = UnityEngine.UI.Image;

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

            root.Add(GetToggleAutoLoad());

            root.Add(GetOther());

            ShowIconPresetApplierButton();

            return root;
        }

        private VisualElement GetForecastCount()
        {
            var root = new VisualElement();

            var forecastCount = new PropertyField(_forecastCount);
            forecastCount.Bind(serializedObject);
            root.Add(forecastCount);

            return root;
        }

        private VisualElement GetToggleAutoLoad(){
            var root = new VisualElement();

            var disableAutoLoad = new Toggle("Disable Auto Load")
            {
                bindingPath = nameof(WeatherWidgetBase.disableAutoLoad)
            };
            disableAutoLoad.Bind(serializedObject);
            root.Add(disableAutoLoad);

            return root;
        }

        private void ShowIconPresetApplierButton()
        {
            var openEditor = new Button
            {
                text = "IconPresetApplier"
            };
            openEditor.clicked += () => { IconPresetApplier.ShowWindowWithTarget((WeatherWidgetBase)target); };
            UtilitiesBlock.Add(openEditor);
        }

        private VisualElement GetOther()
        {
            var script = (WeatherWidgetBase)target;
            var foldout = new Foldout
            {
                text = "Other",
                value = false
            };

            if (script.splashImage != null) foldout.Add(GetSplashImageTexture());

            return foldout;
        }

        private VisualElement GetSplashImageTexture()
        {
            var texture = new ObjectField("Splash Image")
            {
                bindingPath = "splashSprite",
                objectType = typeof(Sprite)
            };

            texture.RegisterValueChangedCallback(evt =>
            {
                var newTexture = (Sprite)evt.newValue;
                var splashImageProp = serializedObject.FindProperty("splashImage");
                var splashImage = (Image)splashImageProp.objectReferenceValue;
                var soImage = new SerializedObject(splashImage);
                soImage.Update();
                soImage.FindProperty("m_Sprite").objectReferenceValue = newTexture;
                soImage.ApplyModifiedProperties();
            });

            return texture;
        }

        protected override string GetScriptName()
        {
            return "WeatherWidget";
        }
    }
}
