using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public KeyCode upMove, downMove, rightMove, leftMove;
    [HideInInspector]
    public KeyCode currentUpMove, currentDownMove, currentRightMove, currentLeftMove;

    public KeyCode sprint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentUpMove = upMove;
        currentDownMove = downMove;
        currentRightMove = rightMove;
        currentLeftMove = leftMove;
    }

    public float GetHorizontalMotion()
    {
        float rightwardMotion = GetRightwardMotion() ? 1f : 0f;
        float leftwardMotion = GetLeftwardMotion() ? -1f : 0f;
        return rightwardMotion + leftwardMotion;
    }
    public float GetVerticalMotion()
    {
        float upwardMotion = GetUpwardMotion() ? 1f : 0f;
        float downwardMotion = GetDownwardMotion() ? -1f : 0f;
        return upwardMotion + downwardMotion;
    }
    public bool GetUpwardMotion() { return Input.GetKey(currentUpMove); }
    public bool GetDownwardMotion() { return Input.GetKey(currentDownMove); }
    public bool GetRightwardMotion() { return Input.GetKey(currentRightMove); }
    public bool GetLeftwardMotion() { return Input.GetKey(currentLeftMove); }

    public bool GetSprintInputDown() { return Input.GetKeyDown(sprint); }
    public bool GetSprintInputUp() { return Input.GetKeyUp(sprint); }
}
