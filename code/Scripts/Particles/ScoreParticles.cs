using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class implements string particles.
/// </summary>
public class ScoreParticles : MonoBehaviour
{
    private void Start() {
        this.GetComponent<TMP_Text>().text = ((int) (Score.defaultScorePerHit * Score.Multiplier)).ToString();
    }
}
