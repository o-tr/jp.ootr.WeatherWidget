using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace jp.ootr.WeatherWidget
{
    public class BaseClass : common.BaseClass
    {
        [SerializeField] protected Animator animator;
        [SerializeField] public Image splashImage;
        [SerializeField] public Sprite splashSprite;
        [SerializeField] public Image[] bgImages;
        [SerializeField] public TextMeshProUGUI[] textMeshes;
        [SerializeField] public TMP_InputField[] textInputFields;
        [SerializeField] public Image[] textImages;
    }
}
