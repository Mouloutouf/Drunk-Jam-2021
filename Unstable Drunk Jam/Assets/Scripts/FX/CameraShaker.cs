using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    public float shakeTime = 0.5f;
    public float shakeAmplitude = 5.0f;
    public float shakeFrequency = 5.0f;

    private CinemachineFreeLook cinemachineFreeLook;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineFreeLook = FindObjectOfType<CinemachineFreeLook>();

        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        Noise(shakeAmplitude, shakeFrequency);
        yield return new WaitForSeconds(shakeTime);
        Noise(0, 0);
    }

    void Noise(float ampli, float freq)
    {
        cinemachineFreeLook.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = ampli;
        cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = ampli;
        cinemachineFreeLook.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = ampli;

        cinemachineFreeLook.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = freq;
        cinemachineFreeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = freq;
        cinemachineFreeLook.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = freq;
    }
}
