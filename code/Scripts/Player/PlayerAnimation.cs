using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class manages the animation of the player.
/// </summary>
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private Camera cam;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private Settings settings;

    private InputActions inputActions;

    private InputAction rotation;
    private InputAction movement;

    /// <summary>
    /// Initializes values.
    /// </summary>
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        settings = GameObject.FindGameObjectWithTag("General").GetComponent<Settings>();

        inputActions = InputManager.inputActions;
        rotation = inputActions.Player.Rotation;
        rotation.Enable();
        movement = inputActions.Player.Movement;
        movement.Enable();
    }

    /// <summary>
    /// Sets the values of the animator depending on input (and current input device).
    /// </summary>
    private void Update() {
        if(settings.GetInputDevice() == Settings.InputDevice.KBM) {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x);
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);
            animator.SetFloat("Horizontal", x);
            animator.SetFloat("Vertical", y);
            animator.SetFloat("Speed", Mathf.Abs(movement.ReadValue<Vector2>().x) + Mathf.Abs(movement.ReadValue<Vector2>().y));
        }
        else {
            animator.SetFloat("Horizontal", -rotation.ReadValue<Vector2>().x);
            animator.SetFloat("Vertical", rotation.ReadValue<Vector2>().y);
            animator.SetFloat("Speed", Mathf.Abs(movement.ReadValue<Vector2>().x) + Mathf.Abs(movement.ReadValue<Vector2>().y));
        }
        
    }
}
