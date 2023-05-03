using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the movement of the player.
/// </summary>
public class PlayerMovement : MonoBehaviour
{ 
    private float walkSpeed;
    private float runSpeed;
    private float runStamina;
    private Vector2 moveDir;
    
    private float moveSpeed;
    private bool isRunning;
    private enum State {
        Normal,
        Runing,
    }
    private State state;
    private Rigidbody2D rb;

    /// <summary>
    /// How fast the transtion between walking and running is (values need to be between 0.0f and 1.0f).
    /// </summary>
    private float walkRunTransitionSpeed = 0.2f;
    /// <summary>
    /// How fast the transtion between running and walking is (values need to be between 0.0f and 1.0f).
    /// </summary>
    private float runWalkTransitionSpeed = 0.2f;
    
    
    /// <summary>
    /// Variable needed for both calls of the Mathf.SmoothDamp function.
    /// </summary>
    private float cvWalk = 0;
    /// <summary>
    /// Variable needed for both calls of the Mathf.SmoothDamp function.
    /// </summary>
    private float cvRun = 0;


    private InputActions inputActions;

    private InputAction movement;

    private InputAction running;

    /// <summary>
    /// Initializes values.
    /// </summary>
    void Start()
    {
        walkSpeed = PlayerStats.walkSpeed;
        runSpeed = PlayerStats.runSpeed;
        runStamina = PlayerStats.runStamina;

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
        state = State.Normal;

        inputActions = InputManager.inputActions;

        movement = inputActions.Player.Movement;
        movement.Enable();

        running = inputActions.Player.Running;
        running.Enable(); 
    }

    /// <summary>
    /// Implements running and walking by switching between run and walk state which have different speed values and running reduces in addition stamina.
    /// </summary>
    private void Update()
    {
        float stamina = StaminaBar.instance.getStamina();

        moveDir = movement.ReadValue<Vector2>();

        switch (state) {
            
            case State.Normal:

            moveSpeed = Mathf.SmoothDamp(moveSpeed, walkSpeed, ref cvWalk, runWalkTransitionSpeed);
            

            if(running.ReadValue<float>() > 0.5)
            {
                state = State.Runing;
            }
            
            break;

            case State.Runing:

            stamina -= runStamina * Time.deltaTime;

            moveSpeed = Mathf.SmoothDamp(moveSpeed, runSpeed, ref cvRun, walkRunTransitionSpeed);

            if(stamina < 0)
            {
                stamina = 0;
                moveSpeed = walkSpeed;
                state = State.Normal;
            }

            StaminaBar.instance.setStamina(stamina);

            if(running.ReadValue<float>() < 0.5)
            {
                state = State.Normal;
            }
            break;
        }
    }

    /// <summary>
    /// Moves the rigidbody with a given speed to a given direction.
    /// </summary>
    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    public Vector3 getPosition() {
        return rb.position;
    }
}