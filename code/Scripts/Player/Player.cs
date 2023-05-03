using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

/// <summary>
/// This class manages the health of the player as well as the sound and the vibration if the player gets hit or dies.
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject deathScreen;
    [Header("Sound")]
    [SerializeField]
    private AudioSource hitSound;
    [SerializeField]
    private AudioSource deathSound;
    private int maxHealth;

    private int health;

    /// <summary>
    /// Needed for gamepad vibration.
    /// </summary>
    private PlayerIndex playerIndex;

    void Start()
    {
        maxHealth = PlayerStats.maxHealth;
        health = maxHealth;
    }

    void Update()
    {
        if(health <= 0) {
            deathScreen.SetActive(true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Time.timeScale = 0f;
        }
    }

    private void OnDestroy() {
        Score.addHealthScore(health);
    }

    public void takeDamage(int damage) {
        health -= damage;
        hitSound.Play();
        StartCoroutine(Vibration());
    }

    public int getHealth() {
        return health;
    }

    public int getMaxHealth() {
        return maxHealth;
    }

    
    private IEnumerator Vibration() {
        GamePad.SetVibration(playerIndex, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
