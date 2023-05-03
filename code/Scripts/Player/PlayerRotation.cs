using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class manages the rotation of the player.
/// </summary>
public class PlayerRotation : MonoBehaviour
{
    public Camera cam;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private Settings settings;

    private InputActions inputActions;
    private InputAction rotation;

    /// <summary>
    /// Initializes values.
    /// </summary>
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        settings = GameObject.FindGameObjectWithTag("General").GetComponent<Settings>();
        inputActions = InputManager.inputActions;
        rotation = inputActions.Player.Rotation;
        rotation.Enable();
    }

    void Update()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("PlayerBody").transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    /// <summary>
    /// Calculates the rotation for the currently active input device.
    /// </summary>
    void FixedUpdate() {
        if(settings.GetInputDevice() == Settings.InputDevice.KBM) {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        } else {
            float angle = Mathf.Atan2(rotation.ReadValue<Vector2>().x, rotation.ReadValue<Vector2>().y) * Mathf.Rad2Deg; 
            rb.rotation = angle;
        }
    }
}
