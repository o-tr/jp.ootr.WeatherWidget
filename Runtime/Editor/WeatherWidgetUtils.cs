using jp.ootr.WeatherWidget;
using jp.ootr.WeatherWidget.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class WeatherWidgetUtils : EditorWindow
{
    private readonly Color _defaultBgColor = new Color(0.1640625f, 0.1640625f, 0.1953125f);
    private readonly Color _defaultTextColor = Color.white;
    private IconPreset _iconPreset;

    private WeatherWidgetBase _target;

    private ObjectField _targetField;

    public void CreateGUI()
    {
        var root = rootVisualElement;

        root.Add(GetTargetPicker());

        {
            var fold = new Foldout { text = "Icon Preset Picker" };
            fold.Add(GetIconPresetPicker());
            root.Add(fold);
        }

        {
            var fold = new Foldout { text = "Color Setter" };
            fold.Add(GetColorSetter());
            root.Add(fold);
        }
    }

    [MenuItem("Tools/ootr/WeatherWidgetUtils")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<WeatherWidgetUtils>();
        wnd.titleContent = new GUIContent("WeatherWidgetUtils");
    }

    public static void ShowWindowWithTarget(WeatherWidgetBase target)
    {
        var wnd = GetWindow<WeatherWidgetUtils>();
        wnd.titleContent = new GUIContent("WeatherWidgetUtils");
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

    private VisualElement GetColorSetter()
    {
        var root = new VisualElement();

        var backgroundColor = new ColorField
        {
            label = "Background Color",
            value = new Color(0.1640625f, 0.1640625f, 0.1953125f)
        };
        var textColor = new ColorField
        {
            label = "Text Color",
            value = Color.white
        };

        var applyButton = new Button
        {
            text = "Apply"
        };
        applyButton.RegisterCallback<ClickEvent>(evt =>
        {
            if (_target == null) return;
            ApplyColor(backgroundColor.value, textColor.value);
            _target = default;
            backgroundColor.value = _defaultBgColor;
            textColor.value = _defaultTextColor;
        });
        _targetField.RegisterValueChangedCallback(evt => { applyButton.SetEnabled(evt.newValue != null); });
        applyButton.SetEnabled(false);

        root.Add(backgroundColor);
        root.Add(textColor);
        root.Add(applyButton);

        return root;
    }

    private void ApplyIconPreset()
    {
        if (_target == null || _iconPreset == null) return;
        var so = new SerializedObject(_target);
        so.Update();
        so.FindProperty("c100").objectReferenceValue = _iconPreset.i100;
        so.FindProperty("c101").objectReferenceValue = _iconPreset.i101;
        so.FindProperty("c102").objectReferenceValue = _iconPreset.i102;
        so.FindProperty("c104").objectReferenceValue = _iconPreset.i104;
        so.FindProperty("c110").objectReferenceValue = _iconPreset.i110;
        so.FindProperty("c112").objectReferenceValue = _iconPreset.i112;
        so.FindProperty("c115").objectReferenceValue = _iconPreset.i115;
        so.FindProperty("c200").objectReferenceValue = _iconPreset.i200;
        so.FindProperty("c201").objectReferenceValue = _iconPreset.i201;
        so.FindProperty("c202").objectReferenceValue = _iconPreset.i202;
        so.FindProperty("c204").objectReferenceValue = _iconPreset.i204;
        so.FindProperty("c210").objectReferenceValue = _iconPreset.i210;
        so.FindProperty("c212").objectReferenceValue = _iconPreset.i212;
        so.FindProperty("c215").objectReferenceValue = _iconPreset.i215;
        so.FindProperty("c300").objectReferenceValue = _iconPreset.i300;
        so.FindProperty("c301").objectReferenceValue = _iconPreset.i301;
        so.FindProperty("c302").objectReferenceValue = _iconPreset.i302;
        so.FindProperty("c303").objectReferenceValue = _iconPreset.i303;
        so.FindProperty("c308").objectReferenceValue = _iconPreset.i308;
        so.FindProperty("c311").objectReferenceValue = _iconPreset.i311;
        so.FindProperty("c313").objectReferenceValue = _iconPreset.i313;
        so.FindProperty("c314").objectReferenceValue = _iconPreset.i314;
        so.FindProperty("c400").objectReferenceValue = _iconPreset.i400;
        so.FindProperty("c401").objectReferenceValue = _iconPreset.i401;
        so.FindProperty("c402").objectReferenceValue = _iconPreset.i402;
        so.FindProperty("c403").objectReferenceValue = _iconPreset.i403;
        so.FindProperty("c406").objectReferenceValue = _iconPreset.i406;
        so.FindProperty("c411").objectReferenceValue = _iconPreset.i411;
        so.FindProperty("c413").objectReferenceValue = _iconPreset.i413;
        so.FindProperty("c414").objectReferenceValue = _iconPreset.i414;
        so.FindProperty("c500").objectReferenceValue = _iconPreset.i500;
        so.FindProperty("c501").objectReferenceValue = _iconPreset.i501;
        so.FindProperty("c502").objectReferenceValue = _iconPreset.i502;
        so.FindProperty("c504").objectReferenceValue = _iconPreset.i504;
        so.FindProperty("c510").objectReferenceValue = _iconPreset.i510;
        so.FindProperty("c512").objectReferenceValue = _iconPreset.i512;
        so.FindProperty("c515").objectReferenceValue = _iconPreset.i515;
        so.FindProperty("c601").objectReferenceValue = _iconPreset.i601;
        so.FindProperty("c610").objectReferenceValue = _iconPreset.i610;
        so.FindProperty("c701").objectReferenceValue = _iconPreset.i701;
        so.FindProperty("c711").objectReferenceValue = _iconPreset.i711;
        so.FindProperty("c801").objectReferenceValue = _iconPreset.i801;
        so.FindProperty("c811").objectReferenceValue = _iconPreset.i811;
        so.ApplyModifiedProperties();
    }

    private void ApplyColor(Color bgColor, Color textColor)
    {
        if (_target == null) return;
        var so = new SerializedObject(_target);
        so.Update();
        foreach (var bgImage in _target.bgImages)
        {
            var soImage = new SerializedObject(bgImage);
            soImage.Update();
            soImage.FindProperty("m_Color").colorValue = bgColor;
            soImage.ApplyModifiedProperties();
        }

        foreach (var text in _target.textImages)
        {
            var soText = new SerializedObject(text);
            soText.Update();
            soText.FindProperty("m_Color").colorValue = textColor;
            soText.ApplyModifiedProperties();
        }

        Debug.Log(_target.textMeshes);
        foreach (var tmp in _target.textMeshes)
        {
            var soIcon = new SerializedObject(tmp);
            soIcon.Update();
            soIcon.FindProperty("m_fontColor").colorValue = textColor;
            soIcon.FindProperty("m_faceColor").colorValue = bgColor;
            soIcon.ApplyModifiedProperties();
        }

        foreach (var input in _target.textInputFields)
        {
            var soInput = new SerializedObject(input);
            soInput.Update();
            soInput.FindProperty("m_Colors.m_NormalColor").colorValue = textColor;
            soInput.ApplyModifiedProperties();
        }

        so.ApplyModifiedProperties();
    }
}
