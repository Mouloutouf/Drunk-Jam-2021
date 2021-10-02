using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineFreeLook cinemachineFreeLook;

    public CrowdManager crowdManager;

    public Transform player;

    public void SwitchCam()
    {
        int npc = Random.Range(0, crowdManager.victimeList.Count);
        GameObject victime = crowdManager.victimeList[npc];

        cinemachineFreeLook.Follow = victime.transform;
    }
    public void SwitchBackCam()
    {
        cinemachineFreeLook.Follow = player;
    }
}
