using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class implements the functionality of the credits menu.
/// </summary>
public class CreditsMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject firstButton;

    /// <summary>
    /// Selects firstButton.
    /// </summary>
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
