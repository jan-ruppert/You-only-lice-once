using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class implements the general behaviour of the snake boss.
/// </summary>
public class SnakeGeneral : MonoBehaviour
{
    [SerializeField]
    private GameObject lastPart;
    public GameObject LastWagon {
            get {return lastPart;}
            set {lastPart = value;}
        }

    [SerializeField]
    private int numberParts;

    public int NumberParts {
        get {return numberParts;}
    }

    [SerializeField]
    private int maxNrParts;

    public int MaxNrParts {
        get {return maxNrParts;}
    }

    private void Update() {
        if(this.GetComponent<Enemy>().getCurrentHealth() <= 0) {
            GameObject.FindGameObjectWithTag("General").GetComponent<GeneralBehavior>().LoadNextScene();
        }

        if(lastPart != null) {
            lastPart.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Increases the number of parts.
    /// </summary>
    public void addPart() {
        numberParts++;
    }

    /// <summary>
    /// Decreases the number of parts.
    /// </summary>
    public void removePart() {
        numberParts--;
    }
}
