using jp.ootr.WeatherWidget;
using jp.ootr.WeatherWidget.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class IconPresetApplier : EditorWindow
{
    [SerializeField] private StyleSheet baseStyleSheet;
    private IconPreset _iconPreset;

    private WeatherWidgetBase _target;

    private ObjectField _targetField;

    public void CreateGUI()
    {
        var root = new VisualElement();
        root.styleSheets.Add(baseStyleSheet);
        root.AddToClassList("root");

        root.Add(GetTargetPicker());
        root.Add(GetIconPresetPicker());

        rootVisualElement.Add(root);
    }

    [MenuItem("Tools/ootr/WeatherWidget/IconPresetApplier")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<IconPresetApplier>();
        wnd.titleContent = new GUIContent("IconPresetApplier");
    }

    public static void ShowWindowWithTarget(WeatherWidgetBase target)
    {
        var wnd = GetWindow<IconPresetApplier>();
        wnd.titleContent = new GUIContent("IconPresetApplier");
        wnd._target = target;
        wnd._targetField.value = target;
    }

    private VisualElement GetTargetPicker()
    {
        var root = new VisualElement();
        _targetField = new ObjectField
        {
            label = "Target",
            objectType = typeof(WeatherWidgetBase),
            value = _target
        };
        _targetField.RegisterValueChangedCallback(evt => { _target = evt.newValue as WeatherWidgetBase; });
        root.Add(_targetField);
        return root;
    }

    private VisualElement GetIconPresetPicker()
    {
        var root = new VisualElement();

        var preset = new ObjectField
        {
            label = "Icon Preset",
            objectType = typeof(IconPreset),
            value = _iconPreset
        };
        var applyButton = new Button
        {
            text = "Apply"
        };
        applyButton.SetEnabled(false);

        var infoBox = new VisualElement();

        _targetField.RegisterValueChangedCallback(evt =>
        {
            applyButton.SetEnabled(_iconPreset != null && evt.newValue != null);
        });

        preset.RegisterValueChangedCallback(evt =>
        {
            _iconPreset = evt.newValue as IconPreset;
            applyButton.SetEnabled(_iconPreset != null && _target != null);
        });

        applyButton.clicked += () =>
        {
            if (_target == null || _iconPreset == null) return;
            ApplyIconPreset();
            _iconPreset = default;
            preset.value = default;
            applyButton.SetEnabled(false);
            infoBox.Clear();
            infoBox.Add(new HelpBox("Applied!", HelpBoxMessageType.Info));
        };

        root.Add(preset);
        root.Add(applyButton);
        root.Add(infoBox);

        return root;
    }

    private void ApplyIconPreset()
    {
        if (_target == null || _iconPreset == null) return;
        var so = new SerializedObject(_target);
        so.Update();
        var icons = so.FindProperty("icons");
        var iconNames = so.FindProperty("iconNames");
        icons.ClearArray();
        iconNames.ClearArray();
        icons.arraySize = _iconPreset.icons.Length;
        iconNames.arraySize = _iconPreset.iconNames.Length;
        for (var i = 0; i < _iconPreset.icons.Length; i++)
        {
            icons.GetArrayElementAtIndex(i).objectReferenceValue = _iconPreset.icons[i];
            iconNames.GetArrayElementAtIndex(i).stringValue = _iconPreset.iconNames[i];
        }

        so.ApplyModifiedProperties();
    }
}
