using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the dash of the player.
/// </summary>
public class Dash : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBody;

    [Header("Sound")]
    [SerializeField]
    private AudioSource dashSound;

    private GameObject dashIndicatorSprite;

    private GameObject dashTarget;

    private Rigidbody2D rb;

    private float dashStamina;

    private float stamina;

    private InputActions inputActions;

    private InputAction dashRotation;

    private InputAction dash;

    /// <summary>
    /// Initializes values.
    /// </summary>
    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        dashIndicatorSprite = this.transform.GetChild(0).gameObject;
        dashTarget = this.transform.GetChild(1).gameObject;
        dashStamina = PlayerStats.dashStamina;

        inputActions = InputManager.inputActions;
        dash = inputActions.Player.Dash;
        dash.Enable();

        dashRotation = inputActions.Player.DashRotation;
        dashRotation.Enable();

        inputActions.Player.Dash.canceled += DoDash;
        inputActions.Player.Dash.Enable();
    }

    /// <summary>
    /// Executes the dash by updating the position of the gameobject and reducing the stamina value.
    /// </summary>
    /// <param name="obj"></param>
    private void DoDash(InputAction.CallbackContext obj) {
        if(!dashTarget.GetComponent<DashTarget>().TargetCollides && stamina >= dashStamina) {
            playerBody.transform.position = dashTarget.transform.position;
            stamina -= dashStamina;
            StaminaBar.instance.setStamina(stamina);
            dashSound.Play();
        }
    }

    /// <summary>
    /// Executes the DoDash()-method depending on input and on the current stamina value. Turns the dash indicator red if the dash can not be executed.
    /// </summary>
    void Update()
    {
        stamina = StaminaBar.instance.getStamina();

        this.transform.position = playerBody.transform.position;

        float angle = Mathf.Atan2(dashRotation.ReadValue<Vector2>().x, dashRotation.ReadValue<Vector2>().y) * Mathf.Rad2Deg;

        rb.rotation = angle;

        if(dash.ReadValue<float>() > 0.5f) {
            dashIndicatorSprite.SetActive(true);
            if(dashTarget.GetComponent<DashTarget>().TargetCollides || stamina <= dashStamina)
                dashIndicatorSprite.GetComponent<SpriteRenderer>().color = Color.red;
            else
                dashIndicatorSprite.GetComponent<SpriteRenderer>().color = Color.white;
        } else {
            dashIndicatorSprite.SetActive(false);
        }
    }
}
