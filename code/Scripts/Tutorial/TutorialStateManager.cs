using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class manages the tutorial states,
/// </summary>
public class TutorialStateManager : MonoBehaviour
{
    private TutorialState currentState;

    [Header("States")]
    [SerializeField]
    private TutorialState firstState;

    [Header("GUI")]
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private TMP_Text keyText;

    private Settings settings;


    private void Start() {
        settings = GameObject.FindGameObjectWithTag("General").GetComponent<Settings>();

        currentState = firstState;
        updateGUI();
    }

    private void Update() {
        currentState.Execute();
        GetNextState();
    }

    public void GetNextState() {
        if(currentState.Done) {
            currentState = currentState.NextState();
            updateGUI();
        }
    }

    /// <summary>
    /// Updates the dialogue and needed tutorial inputs.
    /// </summary>
    private void updateGUI() {
        dialogue.Lines = currentState.Text;
        dialogue.StartDialogue();
        if(settings.GetInputDevice() == Settings.InputDevice.KBM) {
            keyText.text = currentState.KeyText_Keyboard;
        } else {
            keyText.text = currentState.KeyText_Gamepad;
        }
    }
}
