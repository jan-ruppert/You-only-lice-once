using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of a pattern of bullets.
/// </summary>
public class BulletPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject pattern;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotation;

    [SerializeField]
    private Vector3 direction;

    /// <summary>
    /// Moves and rotates the pattern game object. After all child objects (bullets) are destroyed, the object will be destroyed.
    /// </summary>
    private void Update() {
        pattern.transform.position += direction * speed * Time.deltaTime;

        pattern.transform.Rotate(new Vector3(0,0,rotation));

        if(pattern.transform.childCount <= 0) {
            Destroy(pattern);
        }
    }

    /// <summary>
    /// Initializes needed values of the patten.
    /// </summary>
    /// <param name="speed">The movement speed of the pattern.</param>
    /// <param name="rotation">The rotation speed of the pattern</param>
    /// <param name="direction">The headed direction speed of the pattern</param>
    public void setValues(float speed, float rotation, Vector3 direction) {
        this.speed = speed;
        this.direction = direction;
        this.rotation = rotation;
    }
}
