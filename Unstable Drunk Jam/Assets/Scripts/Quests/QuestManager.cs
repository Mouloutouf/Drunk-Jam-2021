using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int winQuestsAmount, loseQuestsAmount;
    private bool winState, loseState;
    private int succeededQuests, failedQuests;

    public GameObject winBox, loseBox;

    public bool useSelectedQuests;
    public List<Quest> selectedQuests;
    public static List<Quest> allQuests = new List<Quest>();

    private List<Quest> quests = new List<Quest>();
    private Quest currentQuest;

    private int currentIndex;

    public string timeLeftString;
    public TextMeshProUGUI timerText;

    public string patchVersion;
    public TextMeshProUGUI patchText;

    private Quest previousQuest;

    void Start()
    {
        currentQuest = SelectRandomQuest();
        currentQuest.StartQuest();
    }

    void Update()
    {
        if (winState || loseState) return;

        if (currentQuest.Completion())
        {
            Debug.Log("Quest completed!");
            currentQuest.onWinQuest.Invoke();
            succeededQuests++;
            NextQuest();
        }
        if (currentQuest.TimeOut())
        {
            Debug.Log("Quest failed!");
            currentQuest.onLoseQuest.Invoke();
            failedQuests++;
            NextQuest();
        }
        if (timerText != null) timerText.text = timeLeftString + " " + currentQuest.currentTime.ToString("F2");
    }

    Quest SelectRandomQuest()
    {
        var qList = useSelectedQuests ? selectedQuests : allQuests;
        foreach (var q in qList)
        {
            if (q == previousQuest) continue;
            quests.Add(q);
        }
        int i = Random.Range(0, quests.Count);
        return quests[i];
    }

    void NextQuest()
    {
        if (patchText != null) patchText.text = patchVersion + (succeededQuests + failedQuests).ToString();

        if (succeededQuests >= winQuestsAmount)
        {
            winState = true;
            Debug.Log("You Win!");
            winBox.SetActive(true);
        }
        if (failedQuests >= loseQuestsAmount)
        {
            loseState = true;
            Debug.Log("You Lose!");
            loseBox.SetActive(true);
        }

        previousQuest = currentQuest;

        currentQuest.EndQuest();

        currentQuest = SelectRandomQuest();
        currentQuest.StartQuest();
    }
}
