using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindKeyQuest : Quest
{
    public string[] potentialKeys;
    private string keyToFind;

    public override void StartQuest()
    {
        base.StartQuest();

        keyToFind = potentialKeys[Random.Range(0, potentialKeys.Length)];
    }

    public override bool Completion()
    {
        return Input.inputString == keyToFind;
    }
}