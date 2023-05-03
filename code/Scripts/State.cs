using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This abstract class descibes a state.
/// </summary>
public abstract class State : MonoBehaviour
{
    /// <summary>
    /// Abstract method which is executed, if the state is active.
    /// </summary>
    public abstract void Execute();
}
