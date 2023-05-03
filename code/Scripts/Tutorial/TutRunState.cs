using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the run tutorial.
/// </summary>
public class TutRunState : TutorialState
{
    [Header("GameLogic")]
    // <summary>
    /// Time to press the run keys to complete the tutorial.
    /// </summary>
    [SerializeField]
    private float timeToComplete;

    /// <summary>
    /// Initializes inputs from Unity's New Inputsystem.
    /// </summary>
    private InputActions inputActions;
    private InputAction running;

    private void Start() {
        inputActions = InputManager.inputActions;

        running = inputActions.Player.Running;
        running.Enable();
    }
    
    /// <summary>
    /// Tracks the run inputs and updates the needed time to complete.
    /// </summary>
    public override void Execute()
    {
        if(running.ReadValue<float>() > 0.5f) {
            if(timeToComplete > 0) {
                timeToComplete -= Time.deltaTime;
            } else {
                this.done = true;
            }
        }
    }
}
