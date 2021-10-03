using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : MonoBehaviour
{
    public ThirdPersonMovement movement;

    [HideInInspector]
    public bool sprinting;

    public float sprintSpeed;

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
    }
}
