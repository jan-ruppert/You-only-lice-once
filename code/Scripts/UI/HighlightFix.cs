using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This class implemets a fix, that UIButtons can not be highlighted by mouse and gamepad simultaneously.
/// </summary>  
  
[RequireComponent(typeof(Selectable))]
public class HighlightFix : MonoBehaviour, IPointerEnterHandler, IDeselectHandler
 {
    /// <summary>
    /// Deselects all selected objects, if the pointer enters a new selectable object and selects the new object.
    /// </summary>
    /// <param name="eventData">https://docs.unity3d.com/2017.3/Documentation/ScriptReference/EventSystems.PointerEventData.html</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
            EventSystem.current.SetSelectedGameObject(this.gameObject);
    }
  
    /// <summary>
    /// Deselects all selected objects, if the gamepad selects a new selectable object.
    /// </summary>
    /// <param name="eventData">https://docs.unity3d.com/2017.3/Documentation/ScriptReference/EventSystems.BaseEventData.html</param>
    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Selectable>().OnPointerExit(null);
    }
}
