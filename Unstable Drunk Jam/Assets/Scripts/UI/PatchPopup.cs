using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatchPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI versionText;

    [SerializeField] TextMeshProUGUI missionNameText;
    [SerializeField] TextMeshProUGUI missionDescText;
    [SerializeField] Image leftImage;
    [SerializeField] Image rightImage;

    void Start()
    {
        SetRandomVersion();
    }

    void SetRandomVersion()
    {
        int firstValue = Random.Range(1, 20);
        int secondValue = Random.Range(1, 100);

        versionText.text = "V " + firstValue + "." + secondValue;


        versionText.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
    }

    public void SetMissionPopup(string missionName, string missionDescription, Sprite imageLeft, Sprite imageRight)
    {
        missionNameText.text = missionName;
        missionDescText.text = missionDescription;

        leftImage.sprite = imageLeft;
        rightImage.sprite = imageRight;
    }
}
