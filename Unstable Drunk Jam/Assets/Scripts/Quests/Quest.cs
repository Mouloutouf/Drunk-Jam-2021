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

    public Sprite leftSprite;
    public Sprite rightSprite;

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

    [HideInInspector]
    public ThirdPersonMovement movement;

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
        patchPopup.SetMissionPopup(questName, description, leftSprite, rightSprite);

        movement.locked = true;

        yield return new WaitForSeconds(waitTime);

        patchPopup.gameObject.SetActive(false);

        onStartQuest.Invoke();

        active = true;
        movement.locked = false;
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
