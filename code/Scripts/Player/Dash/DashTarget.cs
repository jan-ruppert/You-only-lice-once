using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the target the player is dashing towards.
/// </summary>
public class DashTarget : MonoBehaviour
{
    /// <summary>
    /// Saves if the dash-target-gameobject collides.
    /// </summary>
    private bool targetCollides;
    public bool TargetCollides {get {return targetCollides;}}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Border") {
            targetCollides = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.tag == "Border") {
            targetCollides = false;
        }
    }
}
