using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the shooting tutorial.
/// </summary>
public class TutShootState : TutorialState
{
    [Header("GameLogic")]
    /// <summary>
    /// Time to press the shooting keys to complete the tutorial.
    /// </summary>
    [SerializeField]
    private float timeToComplete;
    /// <summary>
    /// Initializes inputs from Unity's New Inputsystem.
    /// </summary>
    private InputActions inputActions;
    private InputAction shooting;

    private void Start() {
        inputActions = InputManager.inputActions;

        shooting = inputActions.Player.Shooting;
        shooting.Enable();
    }
    
    /// <summary>
    /// Tracks the shooting inputs and updates the needed time to complete.
    /// </summary>
    public override void Execute()
    {
        if(shooting.ReadValue<float>() > 0.5f) {
            if(timeToComplete > 0) {
                timeToComplete -= Time.deltaTime;
            } else {
                this.done = true;
            }
        }
    }
}
