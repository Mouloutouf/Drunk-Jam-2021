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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("yes");
            sprinting = true;
            movement.SetSpeed(sprintSpeed);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
            movement.SetSpeed(movement.speed);
        }
    }
}
