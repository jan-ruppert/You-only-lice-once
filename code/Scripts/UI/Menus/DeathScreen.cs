using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

/// <summary>
/// This class implements the functionality of the deathscreen.
/// </summary>
public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;

    [SerializeField]
    private TMP_Text scoreText;

    private PlayerIndex playerIndex;

    private GamePadState gamePadState;

    /// <summary>
    /// Safes highscore, shows the reached score and disables gamepad vibration.
    /// </summary>
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(firstButton);
        GamePad.SetVibration(playerIndex, 0f, 0f);
        Score.safeHighScore();
        showScore();
    }

    /// <summary>
    /// Loads the main menu.
    /// </summary>
    public void LoadMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManagement.MainMenu);
        PlayerStats.reset();
        SceneManagement.resetBoss();
        PickedItems.reset();
    }

    /// <summary>
    /// Displays the score on death screen.
    /// </summary>
    private void showScore() {
        if(Score.PlayerScore > Score.HighScore)
            scoreText.text = "NEW HIGHSCORE!\nScore: " + Score.PlayerScore;
        else
            scoreText.text = "Score: " + Score.PlayerScore;
    }
}
