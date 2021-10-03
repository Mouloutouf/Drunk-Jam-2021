using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVictimFeedback : MonoBehaviour
{
    public SwitchCamera switchCamera;

    public GameObject killFeedbackPrefab;

    public void KillVictim()
    {
        if (killFeedbackPrefab != null) Instantiate(killFeedbackPrefab, switchCamera.victim.transform.position, Quaternion.identity);
    }
}
