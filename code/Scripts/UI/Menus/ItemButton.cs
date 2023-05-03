using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class implements the functionality of an item button.
/// </summary>
public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    private ScoreInfo scoreInfo;
    [SerializeField]
    private ItemScreen itemScreen;
    [SerializeField]
    private int number;

    private Item item;

    public Item Item {
        set{item = value;}
    }

    public string Description{
        get {return item.Description;}
    }

    /// <summary>
    /// Sets modifier of the score info to the item of this item button, if pointer enters the button.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        scoreInfo.setModifier(item.Multiplier);
        itemScreen.SelectedButton = number;
    }

    /// <summary>
    /// Resets modifier of the score info, if the pointer exits the button.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        scoreInfo.resetModifier();
    }

    /// <summary>
    /// Sets modifier of the score info to the item of this item button, if button is selected.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnSelect(BaseEventData eventData)
    {
        scoreInfo.setModifier(item.Multiplier);
    }
    
    /// <summary>
    /// Resets modifier of the score info, if button is deselected.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDeselect(BaseEventData eventData)
    {
        scoreInfo.resetModifier();
    }

    /// <summary>
    /// Safes the picked item.
    /// </summary>
    public void SafeItem() {
        PickedItems.items.Add(item);
    }
}