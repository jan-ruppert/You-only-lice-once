using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the move tutorial.
/// </summary>
public class TutMoveState : TutorialState
{
    [Header("GameLogic")]
    /// <summary>
    /// Time to press the movement keys to complete the tutorial.
    /// </summary>
    [SerializeField]
    private float timeToComplete;
    private InputActions inputActions;
    private InputAction movement;

    /// <summary>
    /// Initializes inputs from Unity's New InputSystem.
    /// </summary>
    private void Start() {
        inputActions = InputManager.inputActions;

        movement = inputActions.Player.Movement;
        movement.Enable();
    }
    
    /// <summary>
    /// Tracks the movement inputs and updates the needed time to complete.
    /// </summary>
    public override void Execute()
    {
        if(movement.ReadValue<Vector2>().x > 0.5f || movement.ReadValue<Vector2>().y > 0.5f) {
            if(timeToComplete > 0) {
                timeToComplete -= Time.deltaTime;
            } else {
                this.done = true;
            }
        }
    }
}
