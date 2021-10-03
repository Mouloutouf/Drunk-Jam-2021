using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharlie : MonoBehaviour
{
    public CrowdManager crowdManager;

    public InteractionArea interactionArea;

    private GameObject victim;

    public void SetTargetToCharlie()
    {
        int npc = Random.Range(0, crowdManager.victimeList.Count);
        victim = crowdManager.victimeList[npc];

        victim.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 180);

        interactionArea.transform.SetParent(victim.transform);
        interactionArea.transform.localPosition = Vector3.zero;
    }
    public void SetTargetBack()
    {
        victim.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);

        interactionArea.transform.SetParent(null);
        interactionArea.transform.localPosition = Vector3.forward * 200f;
    }
}
