using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the general behaviour of a snake part.
/// </summary>
public class PartGeneral : MonoBehaviour
{
    private GameObject snakeBoss;
    private GameObject followingPart;

    private void Start() {
        snakeBoss = GameObject.FindGameObjectWithTag("SnakeBoss").transform.GetChild(0).gameObject;
        followingPart = this.GetComponent<PartMovement>().FollowingObject;
    }

    /// <summary>
    /// Fixes bug, if following part has no following object.
    /// </summary>
    private void Update() {
        if(followingPart == null) {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Sets last part of the snake to following part.
    /// </summary>
    private void OnDestroy() {
        if(snakeBoss != null) {
            snakeBoss.GetComponent<SnakeGeneral>().LastWagon = followingPart;
            snakeBoss.GetComponent<SnakeGeneral>().removePart();
        }
    }

    /// <summary>
    /// Starts the flashing of the snake part.
    /// </summary>
    /// <param name="nr">How often the snake part flashes.</param>
    public void PartBlink(int nr) {
        StartCoroutine(Blink(nr));
    }

    /// <summary>
    /// Changes the color of the gameobject for a short amount of time.
    /// </summary>
    /// <param name="nr">Number of changes.</param>
    /// <returns></returns>
    private IEnumerator Blink(int nr) {
        for(int i = 0; i < nr; i++) {
            this.GetComponent<SpriteRenderer>().color = Color.green;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
