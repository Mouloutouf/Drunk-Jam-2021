using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Quest : MonoBehaviour
{
    [HideInInspector]
    public bool completed;

    public float completionTime;
    [HideInInspector]
    public float currentTime;

    public string questName;
    [TextArea]
    public string description;

    public Sprite questSprite;

    public TextMeshProUGUI text;

    public UnityEvent onStartQuest;
    public UnityEvent onWinQuest;
    public UnityEvent onLoseQuest;
    public UnityEvent onEndQuest;

    [HideInInspector] public bool usePopup;
    [HideInInspector] public PatchPopup patchPopup;
    [HideInInspector] public float popupTime;
    private float waitTime;

    [HideInInspector]
    public bool active;

    private void OnEnable()
    {
        QuestManager.allQuests.Add(this);
    }
    private void OnDisable()
    {
        QuestManager.allQuests.Remove(this);
    }

    public virtual void StartQuest()
    {
        currentTime = completionTime;
        text.text = description;

        waitTime = usePopup ? popupTime : 0f;
        StartCoroutine(StartPopup());
    }

    IEnumerator StartPopup()
    {
        patchPopup.gameObject.SetActive(true);
        patchPopup.SetMissionPopup(questName, description, questSprite, questSprite);

        yield return new WaitForSeconds(waitTime);

        patchPopup.gameObject.SetActive(false);

        onStartQuest.Invoke();

        active = true;
    }

    public abstract bool Completion();
    public bool TimeOut()
    {
        if (currentTime <= 0f)
        {
            return true;
        }
        currentTime -= Time.deltaTime;
        return false;
    }

    public virtual void EndQuest()
    {
        active = false;

        onEndQuest.Invoke();
    }
}
