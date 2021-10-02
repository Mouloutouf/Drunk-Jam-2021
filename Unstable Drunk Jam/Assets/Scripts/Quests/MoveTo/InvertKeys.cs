using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertKeys : MonoBehaviour
{
    public KeyCode invertedUpMove, invertedDownMove, invertedRightMove, invertedLeftMove;

    public void InvertMoveKeys()
    {
        InputManager.instance.currentDownMove = invertedDownMove;
        InputManager.instance.currentUpMove = invertedUpMove;
        InputManager.instance.currentRightMove = invertedRightMove;
        InputManager.instance.currentLeftMove = invertedLeftMove;
    }
    public void InvertBackMoveKeys()
    {
        InputManager.instance.currentDownMove = InputManager.instance.downMove;
        InputManager.instance.currentUpMove = InputManager.instance.upMove;
        InputManager.instance.currentRightMove = InputManager.instance.rightMove;
        InputManager.instance.currentLeftMove = InputManager.instance.leftMove;
    }
}
