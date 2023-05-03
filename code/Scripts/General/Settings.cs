using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the active input device.
/// </summary>
public class Settings : MonoBehaviour {

    private const int KBM = 0;
    private const int GAMEPAD = 1;

    public enum InputDevice {KBM, GamePad}
    [SerializeField]
    private InputDevice current;

    private void Start() {
        if(PlayerPrefs.GetInt("Input") == KBM) {
            current = InputDevice.KBM;
        } else if(PlayerPrefs.GetInt("Input") == GAMEPAD) {
            current = InputDevice.GamePad;
        }
    }

    public InputDevice GetInputDevice() {
        return current;
    }

    public void changeInputDevice() {
        switch (current) {
            case InputDevice.KBM: 
                current = InputDevice.GamePad;
                PlayerPrefs.SetInt("Input", GAMEPAD);
                break;
            case InputDevice.GamePad:
                current = InputDevice.KBM;
                PlayerPrefs.SetInt("Input", KBM);
                break;
        }
    }
}

