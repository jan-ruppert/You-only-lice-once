using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class implements the death state of the slime boss.
/// </summary>
public class DeathState : State
{
    public override void Execute() {
        GameObject.FindGameObjectWithTag("General").GetComponent<GeneralBehavior>().LoadNextScene();
    }
}
