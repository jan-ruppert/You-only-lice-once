using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GeneralBehavior : MonoBehaviour
{
    
    private const float StandardTimeScale = 1f;

    private const bool PauseMenuInvisible = false;
    [SerializeField]
    private bool resetScore = false;

    [SerializeField]
    private float timeScale = StandardTimeScale;

    public float TimeScale {get{return timeScale;}} 

    //the pause menu gameobject of the scene
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private float secondsNextScene;

    private InputActions inputActions;

    private InputAction pause;

    void Start()
    {
        if(resetScore)
            Score.resetScore();
        //set the timescale to default value
        Time.timeScale = StandardTimeScale;
        //set pause menu invisible
        pauseMenu.SetActive(PauseMenuInvisible);
        //lock mouse cursor inside the game
        Cursor.lockState = CursorLockMode.Confined;

        inputActions = new InputActions();
        inputActions.Player.Pause.performed += DoPause;
        inputActions.Player.Pause.Enable();
    }

    private void DoPause(InputAction.CallbackContext obj) {
        if(pauseMenu != null) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void LoadNextScene() {
        StartCoroutine(NewScene());
    }

    private IEnumerator NewScene() {
        yield return new WaitForSeconds(secondsNextScene);
        SceneManager.LoadScene(SceneManagement.ItemSelectScene);
    }
}
