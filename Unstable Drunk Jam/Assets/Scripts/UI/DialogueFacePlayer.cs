using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFacePlayer : MonoBehaviour
{
    public Transform canvasTransform;

    public Transform cameraTransform;

    public float smoothVelocity;
    public float smoothTime;

    void Update()
    {
       float target = cameraTransform.eulerAngles.y;
       float angle = Mathf.SmoothDampAngle(canvasTransform.eulerAngles.y, target, ref smoothVelocity, smoothTime);
       canvasTransform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
