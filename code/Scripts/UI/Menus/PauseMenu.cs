using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

/// <summary>
/// This class implements the functionality of the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;
    private Texture2D crosshair;
    private static bool isPaused = false;

    private PlayerIndex playerIndex;

    private GamePadState gamePadState;

    private void Start() {
        crosshair = GameObject.FindGameObjectWithTag("General").GetComponent<SetCursor>().CursorTexture;
    }

    public bool getIsPaused() {
        return isPaused;
    }

    /// <summary>
    /// Selects firstbutton, sets time scale to 0 and sets cursor to default.
    /// </summary>
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(firstButton);
        
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        Time.timeScale = 0f;

        isPaused = true;

        GamePad.SetVibration(playerIndex, 0f, 0f);
    }

    /// <summary>
    /// Sets cursor to crosshair, time scale to default time scale.
    /// </summary>
    private void OnDisable() {
        if(!(SceneManager.GetActiveScene().buildIndex == SceneManagement.ItemSelectScene))
            Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);

        if(GameObject.FindGameObjectWithTag("General") != null)
            Time.timeScale = GameObject.FindGameObjectWithTag("General").GetComponent<GeneralBehavior>().TimeScale;
        isPaused = false;
    }

    /// <summary>
    /// Loads main menu and resets current run data.
    /// </summary>
    public void LoadMainMenu() {
        GamePad.SetVibration(playerIndex, 0f, 0f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManagement.MainMenu);
        Score.safeHighScore();
        PlayerStats.reset();
        SceneManagement.resetBoss();
        PickedItems.reset();
    }

    public void selectFirstButton() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
