using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/// <summary>
/// This class describes the dialogue system.
/// </summary>

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;
    
    [SerializeField]
    private float textSpeed;

    private InputActions inputActions;
    private InputAction enter;
    
    private int index;
    private List<string> lines;

    private bool done = false;
    public bool Done {
        get{return done;}
    }
    public string[] Lines {
        set{lines = new List<string>(value);}
    }


    private void Start() {
        inputActions = InputManager.inputActions;
        inputActions.Player.Dialogue.performed += DoEnter;
        inputActions.Player.Dialogue.Enable();

        textComponent.text = string.Empty;
    }

    private void DoEnter(InputAction.CallbackContext obj) {
        if (textComponent.text == lines[index]) {
            NextLine();
        } else {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    /// <summary>
    /// Starts the dialogue system.
    /// </summary>
    public void StartDialogue() {
        index = 0;
        textComponent.text = string.Empty;
        done = false;
        StartCoroutine(TypeLine());
    }

    /// <summary>
    /// Types each character one by one.
    /// </summary>
    IEnumerator TypeLine() {
        foreach(char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    /// <summary>
    /// Starts the next line or marks dialogue as done if last line was displayed.
    /// </summary>
    private void NextLine() {
        if (index < lines.Count - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            done = true;
        }
    }
}
