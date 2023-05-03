using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class implements the functionality of the unlockables menu.
/// </summary>
public class UnlockabelsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject firstButton;
    [SerializeField]
    private ItemPanel itemPanel;

    private List<GameObject> items;

    private int currentItem;

    /// <summary>
    /// Loads all items (buffs and debuffs) and sorts them.
    /// </summary>
    private void Start() {
        GameObject[] buffArray = Resources.LoadAll<GameObject>("Buffs");

        GameObject[] debuffArray = Resources.LoadAll<GameObject>("Debuffs");

        items = new List<GameObject>(buffArray);

        items.AddRange(debuffArray);

        items.Sort((IComparer<GameObject>) new sortItems());

        currentItem = 0;
    }

    private void Update() {
        itemPanel.Item = items[currentItem].GetComponent<Item>();
    }

    /// <summary>
    /// Selects the first button.
    /// </summary>
    private void OnEnable() {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void nextItem() {
        currentItem = (currentItem + 1) % items.Count; 
    }

    public void previousItem() {
        if(currentItem == 0)
            currentItem = items.Count - 1;
        else
            currentItem--;
    }

    /// <summary>
    /// Sorts items by their unlock score value (ascending).
    /// </summary>
    private class sortItems : IComparer<GameObject> {
        int IComparer<GameObject>.Compare(UnityEngine.GameObject x, UnityEngine.GameObject y) {
            int o1 = x.GetComponent<Item>().UnlockScore;
            int o2 = y.GetComponent<Item>().UnlockScore;

            return o1.CompareTo(o2);
        }
    }
}
