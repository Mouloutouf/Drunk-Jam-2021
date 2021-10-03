using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController characterController;

    public CinemachineFreeLook freeLook;

    public Transform cameraTransform;

    public float speed;

    public float smoothTime;
    public float smoothVelocity;

    public float currentSpeed;

    public bool locked;

    private void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        if (locked) return;

        float horizontal = InputManager.instance.GetHorizontalMotion();
        float vertical = InputManager.instance.GetVerticalMotion();

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float target = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, target, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }

    public void SetSpeed(float _value)
    {
        currentSpeed = _value;
    }
}
