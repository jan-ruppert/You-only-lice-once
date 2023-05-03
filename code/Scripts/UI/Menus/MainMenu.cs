using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// This class implements the functionality of the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;

    [SerializeField]
    private HighScoreText highScoreText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(firstButton);

        Score.HighScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.Refresh();
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void startGame() {
        Score.resetScore();
        SceneManager.LoadScene(SceneManagement.getStartBoss());
    }

    /// <summary>
    /// Starts the tutorial.
    /// </summary>
    public void startTutorial() {
        Score.resetScore();
        SceneManager.LoadScene(SceneManagement.Tutorial);
    }

    /// <summary>
    /// Closes the game.
    /// </summary>
    public void quitGame()
    {
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
    
    /// <summary>
    /// Selects the firstButton.
    /// </summary>
    public void selectFirstButton() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
