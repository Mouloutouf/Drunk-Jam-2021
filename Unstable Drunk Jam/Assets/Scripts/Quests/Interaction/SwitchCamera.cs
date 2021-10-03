using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineFreeLook cinemachineFreeLook;

    public CrowdManager crowdManager;

    public Transform player;

    [HideInInspector]
    public GameObject victim;

    public GameObject interactionArea;

    public void SwitchCam()
    {
        int npc = Random.Range(0, crowdManager.victimeList.Count);
        victim = crowdManager.victimeList[npc];

        cinemachineFreeLook.LookAt = victim.transform;

        interactionArea.transform.SetParent(victim.transform);
        interactionArea.transform.localPosition = Vector3.zero;
    }
    public void SwitchBackCam()
    {
        cinemachineFreeLook.LookAt = player;

        interactionArea.transform.SetParent(null);
        interactionArea.transform.localPosition = Vector3.forward * 200f;
    }
}
