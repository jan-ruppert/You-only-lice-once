using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the movement of a snakepart.
/// </summary>
public class PartMovement : MonoBehaviour
{
    private const int minMagnitude = 2;

    [SerializeField]
    private GameObject followingObject;

    public GameObject FollowingObject {
        get {return followingObject;}
        set {followingObject = value;}
    }
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float rotationModifier;
    private GameObject part;
    private Vector3 moveDirection;

    private void Start() {
        part = this.gameObject;
    }

    /// <summary>
    /// Gameobject follows following object if the magnitude between the position of both objects is greater then minMagnitude.
    /// </summary>
    private void Update() {
        moveDirection = new Vector3();

        var wagonPosition = part.transform.position;
        var objectPosition = followingObject.transform.position;

        if (Vector3.Magnitude(objectPosition - wagonPosition) >= minMagnitude){
            moveDirection = objectPosition - wagonPosition;

            part.transform.position = wagonPosition + Vector3.Normalize(moveDirection) * moveSpeed * Time.deltaTime;  

            Vector3 vectorToTarget = objectPosition - wagonPosition;

            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
