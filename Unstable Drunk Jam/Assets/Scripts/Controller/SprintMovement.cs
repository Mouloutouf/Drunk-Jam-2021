using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMovement : MonoBehaviour
{
    ThirdPersonMovement movement;

    public bool sprinting;

    public float sprintSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
    }
}
