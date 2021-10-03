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

    [TextArea]
    public string description;

    public TextMeshProUGUI text;

    public UnityEvent onStartQuest;
    public UnityEvent onWinQuest;
    public UnityEvent onLoseQuest;
    public UnityEvent onEndQuest;

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

        StartPopup();

        onStartQuest.Invoke();
    }

    IEnumerator StartPopup()
    {


        yield return new WaitForSeconds(1.0f);


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
        onEndQuest.Invoke();
    }
}
