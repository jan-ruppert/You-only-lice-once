using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class implements the countdown timer in the beginning of a scene.
/// </summary>
public class CountdownController : MonoBehaviour
{
    private const float OneSecond = 1f;

    private const string Go = "GO!";

    /// <summary>
    /// The duration of the countdown.
    /// </summary>
    [SerializeField]
    private int countdownTime;
    /// <summary>
    /// Display of countdown.
    /// </summary>
    [SerializeField]
    private TMP_Text countdownDisplay;
    /// <summary>
    /// If countdown is running.
    /// </summary>
    private bool isCountdownActive;

    public bool IsCountdownActive {
        get {return isCountdownActive;}
    }

    /// <summary>
    /// Starts countdown and sets isCountdownActive to true.
    /// </summary>
    private void Start() {
        isCountdownActive = true;

        StartCoroutine(CountdownToStart());
    }

    /// <summary>
    /// Implements countdown by counting countdown time backwards and waiting one second between each count.
    /// If countdown time reaches 1, next step is changing the string to "Go!" and waiting one second.
    /// Finally setting isCountdownActive to false, changing the timescale to default and disabling the countdown display.
    /// </summary>
    /// <returns>null</returns>
    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(OneSecond);

            countdownTime--;
        }

        countdownDisplay.text = Go;

        isCountdownActive = false;
        
        Time.timeScale = GameObject.FindGameObjectWithTag("General").GetComponent<GeneralBehavior>().TimeScale;

        yield return new WaitForSeconds(OneSecond);

        countdownDisplay.gameObject.SetActive(false);
    }
}
