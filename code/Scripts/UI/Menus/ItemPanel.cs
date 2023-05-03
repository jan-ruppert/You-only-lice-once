using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class implements the ui of a item panel.
/// </summary>
public class ItemPanel : MonoBehaviour
{
    private const string textStart = "Required score to unlock: ";

    private const string newLine = "\n";
    private Item item;

    public Item Item{
        set{item = value;}
    }

    [SerializeField]
    private TMP_Text textField;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Color buffColor;
    [SerializeField]
    private Color debuffColor;

    /// <summary>
    /// Initializes text and icon of the item panel for the given icon.
    /// </summary>
    private void Update() {
        textField.text = textStart + item.UnlockScore + newLine + item.ButtonText;
        image.sprite = item.Icon;
        if(item.Unlocked)
        {
            this.gameObject.GetComponent<Image>().color = Color.white;
            image.GetComponent<Image>().color = Color.white;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = Color.grey;
            image.GetComponent<Image>().color = Color.white;
        }
        if(item.Multiplier > 1)
            image.color = debuffColor;
        else
            image.color = buffColor;
    }
}
