using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This call implements the functionality of the UI-rebind-panel.
/// </summary>
public class ReBindPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;

    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
