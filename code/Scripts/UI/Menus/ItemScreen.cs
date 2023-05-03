using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class implements the functionality of the item select screen.
/// </summary>
public class ItemScreen : MonoBehaviour
{
    private const int NumberButtons = 3;

    [SerializeField]
    private List<GameObject> buttons;

    [SerializeField]
    private Color buffColor;
    [SerializeField]
    private Color debuffColor;
    public List<GameObject> Buttons {
        get{return buttons;}
    }

    private GameObject[] selectedItems = new GameObject[NumberButtons];

    private List<GameObject> buffList;

    private List<GameObject> debuffList;

    private int selectedButton = 0;

    public int SelectedButton {
        get{return selectedButton;}
        set{selectedButton = value;}
    }
    
    /// <summary>
    /// Selects how many buffs and debuffs are displayed for choice depending on current multiplier.
    /// </summary>
    private void Start() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        loadItems();

        switch (Score.Multiplier) {
            case > 10f:
                for(int i = 0; i < NumberButtons; i++) {
                    selectBuff(i);
                }
            break;
            
            case < 0.5f:
                for(int i = 0; i < NumberButtons; i++) {
                    selectDebuff(i);
                }
            break;

            case < 0.8f:
                selectDebuff(0);
                selectDebuff(1);
                selectBuff(2);
            break; 

            default:
                selectDebuff(0);
                selectBuff(1);
                selectBuff(2);
            break;
        }
    }

    /// <summary>
    /// Loads buffs and debuffs and safes each of them in a list.
    /// </summary>
    private void loadItems() {
        GameObject[] buffArray = Resources.LoadAll<GameObject>("Buffs");

        buffList = new List<GameObject>(buffArray);

        List<GameObject> tempList = new List<GameObject>();

        foreach (var buff in buffList) {
            if(buff.GetComponent<Item>().Unlocked)
                tempList.Add(buff);
        }

        buffList = new List<GameObject>(tempList);

        tempList.Clear();

        GameObject[] debuffArray = Resources.LoadAll<GameObject>("Debuffs");

        debuffList = new List<GameObject>(debuffArray);

        foreach (var debuff in debuffList) {
            if(debuff.GetComponent<Item>().Unlocked)
                tempList.Add(debuff);
        }

        debuffList = new List<GameObject>(tempList);
    }

    /// <summary>
    /// Selects a random buff.
    /// </summary>
    /// <param name="i">Number of button it is selected for.</param>
    private void selectDebuff(int i) {
        int j = Random.Range(0, debuffList.Count);

        selectedItems[i] = Instantiate(debuffList[j]);

        debuffList.RemoveAt(j);

        initializeButton(i);
    }

    /// <summary>
    /// Selects a random debuff.
    /// </summary>
    /// <param name="i">Number of button it is selected for.</param>
    private void selectBuff(int i) {
        int j = Random.Range(0, buffList.Count);

        selectedItems[i] = Instantiate(buffList[j]);

        buffList.RemoveAt(j);

        initializeButton(i);
    }

    /// <summary>
    /// Initializes an item button by adding item description and icon.
    /// </summary>
    /// <param name="i">Number of button which is initialized</param>
    private void initializeButton(int i) {
        buttons[i].GetComponent<Button>().onClick.AddListener(selectedItems[i].GetComponent<Item>().applyItem);

        buttons[i].GetComponent<Button>().onClick.AddListener(selectedItems[i].GetComponent<Item>().loadNextScene);

        GameObject buttonText = buttons[i].transform.GetChild(0).gameObject;

        buttonText.GetComponent<TMP_Text>().text = selectedItems[i].GetComponent<Item>().ButtonText;

        GameObject buttonIcon = buttons[i].transform.GetChild(1).gameObject;

        buttonIcon.GetComponent<Image>().sprite = selectedItems[i].GetComponent<Item>().Icon;
        
        if(selectedItems[i].GetComponent<Item>().Multiplier < 1)
            buttonIcon.GetComponent<Image>().color = buffColor;
        else
            buttonIcon.GetComponent<Image>().color = debuffColor;

        buttons[i].GetComponent<ItemButton>().Item = selectedItems[i].GetComponent<Item>();
    }
}
