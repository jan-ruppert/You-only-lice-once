using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class shows the current highscore in a text field.
/// </summary>
public class HighScoreText : MonoBehaviour
{
    private const string highsccore = "Highscore: ";

    private TMP_Text tMP_Text;
    private void Start() {
        tMP_Text = this.GetComponent<TMP_Text>();
        Refresh();
    }

    /// <summary>
    /// Updates the highscore.
    /// </summary>
    public void Refresh() {
        tMP_Text.text = highsccore + Score.HighScore;
    }
}
