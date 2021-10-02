using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    TalkToCharacter,
    KillCharacters,
    HitWalls,
    DeliverObject
}

public abstract class Quest : MonoBehaviour
{
    public QuestType questType;

    public bool completed;

    public float completionTime;
    [HideInInspector]
    public float currentTime;

    public void StartQuest()
    {
        currentTime = completionTime;
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
}