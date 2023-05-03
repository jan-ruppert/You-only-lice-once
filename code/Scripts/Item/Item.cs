using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This is an abstract class describing an buff-/debuff-item
/// </summary>
[System.Serializable]
public abstract class Item : MonoBehaviour
{
    [Header("GameLogic")]

    //value that saves the amount of influence to the specific stat
    [SerializeField]
    protected float amount;

    //saves the multiplier of the item
    [SerializeField]
    protected float multiplier;

    public float Multiplier {get{return multiplier;}}
    
    //if the item is unlocked or not
    [SerializeField]
    protected int unlockScore;

    public int UnlockScore {
        get{return unlockScore;}
    }

    public bool Unlocked {
        get{return unlockScore <= Score.HighScore;}
    }

    [Header("UI")]

    //the icon of the item
    [SerializeField]
    protected Sprite icon;

    public Sprite Icon {get{return icon;}}

    //the button text of the item
    [SerializeField]
    protected string buttonText;

    public string ButtonText {get{
        return this.buttonText+ "\nx" + multiplier; 
    }}

    //the full text description of the item
    [SerializeField]
    [TextArea]
    protected string description;

    public string Description {
        get{
            return description;
        }
    }

    /// <summary>
    /// Method which applies the Item
    /// </summary>
    public abstract void applyItem();

    /// <summary>
    /// Loads the next scene
    /// </summary>
    public void loadNextScene() {
        SceneManager.LoadScene(SceneManagement.getNextBoss());
    }
}
