using jp.ootr.WeatherWidget;
using jp.ootr.WeatherWidget.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class WeatherWidgetUtils : EditorWindow
{
    private WeatherWidgetBase _target;
    private IconPreset _iconPreset;
    
    [MenuItem("Tools/ootr/WeatherWidgetUtils")]
    public static void ShowExample()
    {
        WeatherWidgetUtils wnd = GetWindow<WeatherWidgetUtils>();
        wnd.titleContent = new GUIContent("WeatherWidgetUtils");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        {
            var fold = new Foldout { text = "Icon Preset Picker" };
            fold.Add(GetIconPresetPicker());
            root.Add(fold);
        }
    }

    private VisualElement GetIconPresetPicker()
    {
        var root = new VisualElement();
        
        var target = new ObjectField()
        {
            label = "Target",
            objectType = typeof(WeatherWidgetBase),
        };
        var preset = new ObjectField
        {
            label = "Icon Preset",
            objectType = typeof(IconPreset),
        };
        var applyButton = new Button
        {
            text = "Apply",
        };
        applyButton.SetEnabled(false);

        var infoBox = new VisualElement { };
        
        target.RegisterValueChangedCallback(evt =>
        {
            _target = evt.newValue as WeatherWidgetBase;
            applyButton.SetEnabled(_iconPreset != null && _target != null);
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
            _target = default;
            _iconPreset = default;
            target.value = default;
            preset.value = default;
            applyButton.SetEnabled(false);
            infoBox.Clear();
            infoBox.Add(new HelpBox("Applied!", HelpBoxMessageType.Info));
        };
        
        root.Add(target);
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
}
