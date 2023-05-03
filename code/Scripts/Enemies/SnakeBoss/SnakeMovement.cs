using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the movement of the snake boss.
/// </summary>
public class SnakeMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject positions;
    /// <summary>
    /// List of gameobjects the snake can move to.
    /// </summary>
    [SerializeField]
    private List<GameObject> positionsList;
    /// <summary>
    /// The gameobject the snake chases.
    /// </summary>
    private GameObject chasingPosition;

    [SerializeField]
    private GameObject snakeBoss;

    private Vector3 moveDirection;

    [SerializeField]
    private float moveSpeed;

    private int i;

    private CountdownController countdownController;

    private void Start() {
        initializeList();
        chasingPosition = positionsList[0];
        i = 0;
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
    }

    /// <summary>
    /// Moves gameobject position to a random position of the positions list until the magnitude of both is smaller then one,
    /// then chases an new random picked position.
    /// </summary>
    private void Update() {
        if(!countdownController.IsCountdownActive) {
            moveDirection = new Vector3();

            var trainPosition = snakeBoss.transform.position;
            var objectPosition = chasingPosition.transform.position;

            if (Vector3.Magnitude(objectPosition - trainPosition) >= 1) {
                moveDirection = objectPosition - trainPosition;

                snakeBoss.transform.position = trainPosition + Vector3.Normalize(moveDirection)  * moveSpeed * Time.deltaTime;
            } else {
                i = Random.Range(0, positionsList.Count);
                chasingPosition = positionsList[i];
            }
        }
    }

    private void initializeList(){
        Transform[] allChildren = positions.GetComponentsInChildren<Transform>();
        foreach(Transform child in allChildren) {
            positionsList.Add(child.gameObject);
        }

    }
}
