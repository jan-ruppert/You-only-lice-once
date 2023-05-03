using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class implements the display of previous picked items.
/// </summary>
public class PickedItemImages : MonoBehaviour
{
    [SerializeField]
    private Color buffColor;
    [SerializeField]
    private Color debuffColor;

    /// <summary>
    /// Displays the picked items and colors them depending on the multiplier (if they are a buff or debuff).
    /// </summary>
    void Start()
    {
        var items = PickedItems.items;
        for(int i = 0; i < 4; i++) {
            if(items.Count - i > 0) {
                this.transform.GetChild(i).GetComponent<Image>().sprite = items[items.Count - i - 1].Icon;
                if(items[items.Count - i - 1].Multiplier < 1)
                    this.transform.GetChild(i).GetComponent<Image>().color = buffColor;
                else
                    this.transform.GetChild(i).GetComponent<Image>().color = debuffColor;
            }
        }
    }
}
