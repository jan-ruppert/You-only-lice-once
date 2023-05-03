using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class implements the animation of the player weapon.
/// </summary>
public class WeaponSpriteHandler : MonoBehaviour
{
    /// <summary>
    /// Order of sprites in the weaponSptires list.
    /// </summary>
    private const int up = 0;
    private const int down = 1;
    private const int side = 2;
    private const int diagup = 3;
    private const int diagdown = 4;

    /// <summary>
    /// The sprites of the weapon.
    /// </summary>
    [SerializeField]
    private List<Sprite> weaponSprites;
    private Sprite currentSprite;

    /// <summary>
    /// Saves if the weapons sprite is flipped.
    /// </summary>
    private bool flipped;

    private int frontPlayer;

    private int behindPlayer;

    /// <summary>
    /// Saves the layer order, if the weapon is in front of or behind the player.
    /// </summary>
    private int order;


    private Camera cam;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private Settings settings;

    private InputActions inputActions;

    private InputAction rotation;
    private InputAction movement;

    /// <summary>
    /// Initializes needed variabels.
    /// </summary>
    private void Start() {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<Rigidbody2D>();
        settings = GameObject.FindGameObjectWithTag("General").GetComponent<Settings>();
        frontPlayer = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<SpriteRenderer>().sortingOrder + 1;
        behindPlayer = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<SpriteRenderer>().sortingOrder - 1;
        currentSprite = weaponSprites[down];
        flipped = false;
        order = frontPlayer;

        inputActions = InputManager.inputActions;
        rotation = inputActions.Player.Rotation;
        rotation.Enable();
        movement = inputActions.Player.Movement;
        movement.Enable();
    }

    /// <summary>
    /// Calculates the direction the player is facing to depending on the current input device.
    /// </summary>
    private void Update() {
        float x;
        float y;
        if(settings.GetInputDevice() == Settings.InputDevice.KBM) {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x);
            x = Mathf.Cos(angle);
            y = Mathf.Sin(angle);

        }
        else {
            x = -rotation.ReadValue<Vector2>().x;
            y = rotation.ReadValue<Vector2>().y;
        }

        if(movement.ReadValue<Vector2>().x == 0 && movement.ReadValue<Vector2>().y == 0) {
            currentSprite = weaponSprites[down];
            flipped = false;
            order = frontPlayer;
        } else {
            weaponSprite(x,y);
        }
        
        var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentSprite;
        spriteRenderer.flipX = flipped;
        spriteRenderer.sortingOrder = order;
    }

    /// <summary>
    /// Updates the weapon sprite on a given direction.
    /// </summary>
    /// <param name="x">Horizontal value of the direction.</param>
    /// <param name="y">Vertical value of the direction.</param>
    private void weaponSprite(float x, float y) {
        if(x >= 0.5f) {
            if(y >= 0.5f) {
                currentSprite = weaponSprites[diagup];
                flipped = false;
                order = behindPlayer;
            } else if (y <= -0.5f) {
                currentSprite = weaponSprites[diagdown];
                flipped = false;
                order = frontPlayer;
            } else {
                currentSprite = weaponSprites[side];
                flipped = false;
                order = frontPlayer;
            }
        } else if(x <= -0.5f) {
            if(y >= 0.5f) {
                currentSprite = weaponSprites[diagup];
                flipped = true;
                order = behindPlayer;
            } else if (y <= -0.5f) {
                currentSprite = weaponSprites[diagdown];
                flipped = true;
                order = frontPlayer;
            } else {
                currentSprite = weaponSprites[side];
                flipped = true;
                order = frontPlayer;
            }
        } else {
            if(y >= 0.5f) {
                currentSprite = weaponSprites[up];
                flipped = false;
                order = behindPlayer;
            } else if (y <= -0.5f) {
                currentSprite = weaponSprites[down];
                flipped = false;
                order = frontPlayer;
            } else {
                currentSprite = weaponSprites[down];
                flipped = false;
                order = frontPlayer;
            }
        }
    }
}
