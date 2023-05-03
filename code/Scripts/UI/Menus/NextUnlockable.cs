using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class implements the view of the next unlockable which can be unlock in the death screen.
/// </summary>
public class NextUnlockable : MonoBehaviour
{
    [SerializeField]
    private Image nextImage;
    [SerializeField]
    private TMP_Text nextScore;
    [SerializeField]
    private Image previousImage;
    [SerializeField]
    private TMP_Text previousScore;
    [SerializeField]
    private TMP_Text highScore;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float fillDelay;
    [SerializeField]
    private Color buffColor;
    [SerializeField]
    private Color debuffColor;

    private List<GameObject> items;

    /// <summary>
    /// Displays the previous and next unlockable as well as the current highscore.
    /// </summary>
    private void OnEnable() {
        InitializeItems();
        var next = FindNextUnlockable().GetComponent<Item>();
        var previous = FindPreviousUnlockable().GetComponent<Item>();
        nextImage.sprite = next.Icon;
        nextScore.text = next.UnlockScore.ToString();
        nextImage.color = imageColor(next);
        previousImage.sprite = previous.Icon;
        previousImage.color = imageColor(previous);
        previousScore.text = previous.UnlockScore.ToString();
        highScore.text = Score.HighScore.ToString();
        slider.minValue = previous.UnlockScore;
        slider.maxValue = next.UnlockScore;
        slider.value = Score.HighScore;
    }

    /// <summary>
    /// Loads and sorts all items.
    /// </summary>
    private void InitializeItems() {
        GameObject[] buffArray = Resources.LoadAll<GameObject>("Buffs");

        GameObject[] debuffArray = Resources.LoadAll<GameObject>("Debuffs");

        items = new List<GameObject>(buffArray);

        items.AddRange(debuffArray);

        items.Sort((IComparer<GameObject>) new sortItems());
    }

    /// <summary>
    /// Finds the next unlockable item based on the highscore.
    /// </summary>
    /// <returns>The next unlockable as gameobject.</returns>
    private GameObject FindNextUnlockable() {
        foreach (GameObject item in items) {
            if(item.GetComponent<Item>().UnlockScore > Score.HighScore) {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// Finds the previous unlockable item based on the highscore.
    /// </summary>
    /// <returns>The previous unlockable as gameobject.</returns>
    private GameObject FindPreviousUnlockable() {
        int i = 0;
        foreach (GameObject item in items) {
            if(item.GetComponent<Item>().UnlockScore < Score.HighScore) {
                i++;
            }
        }
        if(i <= 0) {
            return items[0];
        } else {
            return items[i - 1];
        }
    }

    /// <summary>
    /// Returns the color for an item.
    /// </summary>
    /// <param name="item">The item the color is searched for.</param>
    /// <returns>Color depending on item multiplier.</returns>
    private Color imageColor(Item item) {
        if(item.Multiplier > 1)
            return debuffColor;
        else
            return buffColor;
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
