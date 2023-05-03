using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class implements the final state tutorial.
/// </summary>
public class TutFinalState : TutorialState
{
    /// <summary>
    /// Loads first game scene after finishing the dialogue.
    /// </summary>
    public override void Execute()
    {
        if(description.GetComponent<Dialogue>().Done) {
            SceneManager.LoadScene(SceneManagement.FirstBossEasy);
        }
    }
}