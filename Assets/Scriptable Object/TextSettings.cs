using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "TextSettings", menuName = "Custom/TextSettings", order = 1)]
public class TextSettings : ScriptableObject
{
    [Header("Text Settings")]

    public string textTitle;
    [TextArea(3, 10)]
    public string textContent;

    public Color textColor = Color.white;
    public int fontSize = 36;
    public bool useBold = false;
    public bool useItalic = false;
    public bool useUnderline = false;

}
