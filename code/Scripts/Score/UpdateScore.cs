using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class updates the score displayed by a text field.
/// </summary>
public class UpdateScore : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start() {
        textMesh = this.gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        textMesh.text = Score.PlayerScore.ToString();
    }
}
