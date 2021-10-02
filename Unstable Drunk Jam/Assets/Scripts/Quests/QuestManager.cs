using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int winQuestsAmount, loseQuestsAmount;
    private bool winState, loseState;
    private int succeededQuests, failedQuests;

    public GameObject winBox, loseBox;

    //public Dictionary<Quest, QuestBehaviour> questsBehaviours;

    //public List<QuestTemplate> questsTemplates;

    public List<Quest> allQuests;

    private List<Quest> quests;
    private Quest currentQuest;

    private int currentIndex;

    public string timeLeftString;
    public Text timerText;

    void Start()
    {
        CreateQuestSequence();
    }

    void Update()
    {
        if (winState || loseState) return;

        if (currentQuest.Completion())
        {
            Debug.Log("Quest completed!");
            succeededQuests++;
            NextQuest();
        }
        if (currentQuest.TimeOut())
        {
            Debug.Log("Quest failed!");
            failedQuests++;
            NextQuest();
        }
        timerText.text = timeLeftString + " " + currentQuest.currentTime.ToString("F2");
    }

    void CreateQuestSequence()
    {
        //quests = new List<Quest>(loseQuestsAmount);

        // Random Select quests from the quests templates
        // Then generate quests with the different values of the quest template
        quests = allQuests;

        currentQuest = quests[0];
        currentQuest.StartQuest();
    }
    void NextQuest()
    {
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

        currentQuest.EndQuest();

        currentIndex++;
        if (currentIndex >= quests.Count) {
            currentIndex = 0;
        }
        currentQuest = quests[currentIndex];
        currentQuest.StartQuest();
    }
}
