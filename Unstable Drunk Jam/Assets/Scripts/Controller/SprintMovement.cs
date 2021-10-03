using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : MonoBehaviour
{
    public ThirdPersonMovement movement;

    [HideInInspector]
    public bool sprinting;

    public float sprintSpeed;

    [Header("ANIMATION")]
    public Animator animator;
    Vector3 currentLocation;
    Vector3 baseLocation;
    float velocity;

    private void Update()
    {
        if (InputManager.instance.GetSprintInputDown())
        {
            sprinting = true;
            movement.SetSpeed(sprintSpeed);
        }
        else if (InputManager.instance.GetSprintInputUp())
        {
            sprinting = false;
            movement.SetSpeed(movement.speed);
        }

        GetVelocity();
    }

    void GetVelocity()
    {
        currentLocation = transform.position;
        velocity = Vector3.Distance(baseLocation, currentLocation);
        baseLocation = currentLocation;

        if (animator != null)
        {
            animator.SetFloat("RunSpeed", velocity * 10);
        }

        Debug.LogWarning("velocity = " + velocity);
    }
}
