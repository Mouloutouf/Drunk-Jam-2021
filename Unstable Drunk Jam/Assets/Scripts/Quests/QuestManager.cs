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

    public bool usePopup;
    public PatchPopup patchPopup;
    public float popupTime;

    public ThirdPersonMovement movement;

	[Header("FX")]
    public GameObject questFailed_FX;
    public GameObject questValidated_FX;

    void Start()
    {
        currentQuest = SelectRandomQuest();
        StartCurrentQuest();
    }

    void Update()
    {
        if (!currentQuest.active) return;

        if (winState || loseState) return;

        if (currentQuest.Completion())
        {
            ValidatedFX();
            Debug.Log("Quest completed!");
            currentQuest.onWinQuest.Invoke();
            succeededQuests++;
            NextQuest();
        }
        if (currentQuest.TimeOut())
        {
            FailedFX();
            Debug.Log("Quest failed!");
            currentQuest.onLoseQuest.Invoke();
            failedQuests++;
            NextQuest();
        }
        if (timerText != null) timerText.text = timeLeftString + " " + currentQuest.currentTime.ToString("F2");
    }

    void StartCurrentQuest()
    {
        currentQuest.usePopup = usePopup;
        currentQuest.patchPopup = patchPopup;
        currentQuest.popupTime = popupTime;

        currentQuest.movement = movement;

        currentQuest.StartQuest();
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

        if (winState || loseState) return;

        currentQuest = SelectRandomQuest();
        StartCurrentQuest();
    }

    //////FX
    ///

    void FailedFX()
    {
        if(questFailed_FX != null) Instantiate(questFailed_FX);
    }
    void ValidatedFX()
    {
        if (questValidated_FX != null) Instantiate(questValidated_FX);
    }
}
