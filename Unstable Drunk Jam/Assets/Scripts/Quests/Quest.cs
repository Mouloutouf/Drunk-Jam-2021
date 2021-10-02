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

    public virtual void StartQuest()
    {
        currentTime = completionTime;
        text.text = description;

        onStartQuest.Invoke();
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

    public virtual void EndQuest() { }
}
