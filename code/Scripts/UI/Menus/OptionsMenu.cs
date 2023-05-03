using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// This class implements the functionality of the options menu.
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonText;
    [SerializeField]
    private GameObject firstButton;

    private Settings settings;

    private void Start() {
        settings = GameObject.FindGameObjectWithTag("General").GetComponent<Settings>();
        buttonText.GetComponent<TMP_Text>().SetText(settings.GetInputDevice().ToString());
    }

    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    /// <summary>
    /// Changes the input device.
    /// </summary>
    public void ChangeInputDevice() {
        settings.changeInputDevice();
        buttonText.GetComponent<TMP_Text>().SetText(settings.GetInputDevice().ToString());
    }

    /// <summary>
    /// Sets the volume.
    /// </summary>
    /// <param name="volume"></param>
    public void setVolume(float volume) {
        AudioListener.volume = volume;
    }

    public void selectFirstButton() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    /// <summary>
    /// Resets the date of the game to standard values.
    /// </summary>
    public void ResetGamedata() {
        Score.resetHighscore();
    }
}
