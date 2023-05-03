using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the start of the tutorial.
/// </summary>
public class TutStartState : TutorialState
{
    /// <summary>
    /// Marks tutorial part as completed after finishing the dialogue.
    /// </summary>
    public override void Execute()
    {
        if(description.GetComponent<Dialogue>().Done)
            this.done = true;
    }
}
