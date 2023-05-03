using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class implements the ui of a item description.
/// </summary>
public class ItemDescription : MonoBehaviour
{
    private const string header = "Bonus-Description:\n";
    private const string empty = "";

    [SerializeField]
    private ItemScreen itemScreen;
    private TMP_Text tMP_Text;

    private string description;

    public string Description{
        set {description = value;}
    }

    /// <summary>
    /// Initializes the description of an item in a text field.
    /// </summary>
    void Start()
    {
        description = itemScreen.Buttons[itemScreen.SelectedButton].GetComponent<ItemButton>().Description;;
        tMP_Text = this.GetComponent<TMP_Text>();
        tMP_Text.text = header + description;
    }
}
