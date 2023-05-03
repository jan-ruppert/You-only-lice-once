using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using XInputDotNetPure;

/// <summary>
/// This class implements the shooting of the player.
/// </summary>
public class Shooting : MonoBehaviour
{
    /// <summary>
    /// The point the bullet force is directed to.
    /// </summary>
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private PauseMenu pauseMenu;

    [Header("Sound")]
    [SerializeField]
    private AudioSource gunShot;

    private float bulletSpeed;
    [SerializeField]
    private float fireRate;
    private int bulletSpread;
    private CountdownController countdownController;
    private float shootingCounter;

    private InputActions inputActions;

    private InputAction shooting;

    //vibration
    private PlayerIndex playerIndex;

    private GamePadState gamePadState;

    /// <summary>
    /// Initializes values.
    /// </summary>
    private void Start() {
        bulletSpeed = PlayerStats.bulletSpeed;
        bulletSpread = PlayerStats.bulletSpread;
        fireRate = PlayerStats.fireRate;
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
        shootingCounter = 0;


        inputActions = InputManager.inputActions;
        shooting = inputActions.Player.Shooting;
        shooting.Enable();
    }

    /// <summary>
    /// Updates the shooting counter and handles the gamepad vibration.
    /// </summary>
    void Update()
    {
        if(!pauseMenu.getIsPaused() && !countdownController.IsCountdownActive) {
            if(shootingCounter > 0) {
                shootingCounter -= Time.deltaTime;
                if(shootingCounter <= fireRate/2) {
                    GamePad.SetVibration(playerIndex, 0, 0);
                }
            }
        
            if(shooting.ReadValue<float>() > 0.5f && shootingCounter <= 0) {
                Shoot();
                shootingCounter = fireRate;
            }
        }
    }

    /// <summary>
    /// Instantiates player bullet prefabs with a given force and a random direction to simulate bullet spread.
    /// </summary>
    private void Shoot() 
    {
        Quaternion spread = Quaternion.Euler(firePoint.rotation.eulerAngles + new Vector3(0, 0, Random.Range(-bulletSpread, bulletSpread)));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, spread);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * bulletSpeed, ForceMode2D.Impulse);
        gunShot.Play();
        GamePad.SetVibration(playerIndex, 0.3f, 0.3f);
    }
}
