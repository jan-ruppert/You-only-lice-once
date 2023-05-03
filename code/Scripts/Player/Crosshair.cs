using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the gamepad crosshair.
/// </summary>
public class Crosshair : MonoBehaviour
{
    private Settings settings;

    private void Start() {
        settings = GameObject.FindGameObjectWithTag("General").GetComponent<Settings>();
    }

    /// <summary>
    /// Turns the crosshair gameobject invisible if the active inputdevice is keyboard and mouse and visible otherwise.
    /// </summary>
    private void Update() {
        Color invisible = Color.white;
        invisible.a = 0;
        if(settings.GetInputDevice() == Settings.InputDevice.KBM) {
            this.GetComponent<SpriteRenderer>().color = invisible;
            Cursor.visible = true;
        } else {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            Cursor.visible = false;
        }
    }
}