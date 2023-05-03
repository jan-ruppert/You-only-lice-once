using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// This class sets the game to the right resolution
/// </summary>
public class ResolutionManager : MonoBehaviour
{
    //all possible resolutions the current monitor offers
    private static Resolution[] resolutions;

    //the best possible resolution
    private static Resolution maxResolution;

    /// <summary>
    ///Starts the game in the right resolution
    /// </summary>
    private void Awake()
    {
        UpdateGameResolution(Screen.fullScreen);
    }

    /// <summary>
    /// Searches and applies the best fitting resolution
    /// </summary>
    /// <param name="fullScreen">if the full screen should be active</param>
    public static void UpdateGameResolution(bool fullScreen)
    {
        resolutions = Screen.resolutions;
        maxResolution = resolutions[resolutions.Length - 1];
        Screen.SetResolution(maxResolution.width, maxResolution.height, fullScreen);
    }
}
