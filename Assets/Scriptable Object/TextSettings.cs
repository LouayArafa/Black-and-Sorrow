using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "TextSettings", menuName = "Custom/TextSettings", order = 1)]
public class TextSettings : ScriptableObject
{
    [Header("Text Settings")]
    
    [TextArea(3, 10)]
    public string TextTitle;
    public Color TitleTextColor = Color.white;
    public int TitleFontSize = 36;
    public bool TitleUseBold = false;
    public bool TitleUseItalic = false;
    public bool TitleUseUnderline = false;

    [TextArea(3, 10)]
    public string TextBody;

    public Color BodyTextColor = Color.white;
    public int BodyFontSize = 36;
    public bool BodyUseBold = false;
    public bool BodyUseItalic = false;
    public bool BodyUseUnderline = false;

}
