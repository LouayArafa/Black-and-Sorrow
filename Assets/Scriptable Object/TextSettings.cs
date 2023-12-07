using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "TextSettings", menuName = "Custom/TextSettings", order = 1)]
public class TextSettings : ScriptableObject
{
    [Header("When Looked at ")]
    
    [TextArea(3, 10)]
    public string TitleText_Look;
    public Color TitleTextColor_Look = Color.red;
    public int TitleFontSize_Look = 48;
    public bool TitleUseBold_Look = false;
    public bool TitleUseItalic_Look = false;
    public bool TitleUseUnderline_Look = false;

    [TextArea(3, 10)]
    public string BodyText_Look;

    public Color BodyTextColor_Look = Color.white;
    public int BodyFontSize_Look = 36;
    public bool BodyUseBold_Look = false;
    public bool BodyUseItalic_Look = false;
    public bool BodyUseUnderline_Look = false;

    [Space][Space][Space][Space]

    [TextArea(3, 10)]
    public string BodyText_Pick;

    public Color BodyTextColor_Pick = Color.white;
    public int BodyFontSize_Pick = 36;
    public bool BodyUseBold_Pick = false;
    public bool BodyUseItalic_Pick = false;
    public bool BodyUseUnderline_Pick = false;

}
