using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestNik : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI questText = default;
    [SerializeField] private GameObject questBox = default;
    [SerializeField] private Transform[] questPoints = default;

    [Header("Variables")]
    [SerializeField] private float secondsPerQuest = 5;

    private GameObject questBoxClone;
    private int questIndex = 0;

    private void Start()
    {
        QuestsStart();
    }

    public void QuestsStart()
    {
        questIndex = 0;
        NextQuest();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            QuestsStart();
        }
    }

    public void NextQuest()
    {
        questIndex++;
        questText.text = "Quest #" + questIndex.ToString();
    }

    IEnumerator QuestOnGoing()
    {

        yield return new WaitForSeconds(secondsPerQuest);
    }
}