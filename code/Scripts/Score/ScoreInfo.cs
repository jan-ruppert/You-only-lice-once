using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class displays the score and multiplier in the item select screen.
/// </summary>
public class ScoreInfo : MonoBehaviour
{
    private const float standardModifier = 1f;
    private TMP_Text tMP_Text;

    private float modifier;

    private void Start() {
        tMP_Text = this.GetComponent<TMP_Text>();

        modifier = standardModifier;
    }

    /// <summary>
    /// Shows score, multiplier and a modified multiplier.
    /// </summary>
    private void Update() {
        tMP_Text.text = "Score: " + Score.PlayerScore + "\n" +
                        "Multiplier: " + Score.Multiplier.ToString("0.00") + "\n" +
                        "New Multiplier: " + ((Score.Multiplier * modifier).ToString("0.00"));
    }

    public void setModifier(float newValue) {
        modifier = newValue;
    }

    public void resetModifier() {
        modifier = standardModifier;
    }
}
