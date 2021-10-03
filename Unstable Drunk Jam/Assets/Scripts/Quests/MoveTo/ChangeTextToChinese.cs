using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeTextToChinese : MonoBehaviour
{
    public TMP_FontAsset chineseFont;
    public TMP_FontAsset normalFont;

    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI descriptionPopupText;

    public string chineseMessage;

    public void ChinizeText()
    {
        descriptionText.font = chineseFont;
        descriptionPopupText.font = chineseFont;
    }
    public void NormalText()
    {
        descriptionText.font = normalFont;
        descriptionPopupText.font = normalFont;
    }
}
