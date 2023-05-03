using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the shooting of the snake boss.
/// </summary>
public class SnakeShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject snakeBoss;
    /// <summary>
    /// The bullet pattern while the snake has parts.
    /// </summary>
    [SerializeField]
    private GameObject circleShootPattern;
    /// <summary>
    /// The bullet pattern while the snake has no parts.
    /// </summary>
    [SerializeField]
    private GameObject dashPattern;
    [SerializeField]
    private float patternSpeed;

    [SerializeField]
    private float patternRotation;
    [SerializeField]
    private float shootingTime;
    [SerializeField]
    private int patternAmount;
    [SerializeField]
    private float addRotation = 2;
    private float shootingCounter;
    private float plusRotation = 0;

    private CountdownController countdownController;

    private void Start() {
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
    }

    void Update()
    {
        if(!countdownController.IsCountdownActive) {
            if(shootingCounter > 0) {
                shootingCounter -= Time.deltaTime;
            } else {
                if(this.gameObject.GetComponent<SnakeGeneral>().NumberParts == 0) {
                    Shoot(dashPattern);
                } else {
                    Shoot(circleShootPattern);
                }
                shootingCounter = shootingTime;
            }
        }
    }

    /// <summary>
    /// Instantiates bullet patterns around the gameobject and adds them a speed and rotation value.
    /// </summary>
    /// <param name="patternPrefab">The pattern prefab which is instantiated.</param>
    private void Shoot(GameObject patternPrefab) {
        var stepSize = 360f/patternAmount;
            plusRotation = (plusRotation + addRotation) % 360;
            for (int i = 0; i < patternAmount; i++) {
                var direction = Vector3.right * this.GetComponent<Renderer>().bounds.size.x * 1f;
                direction = Quaternion.AngleAxis(i * stepSize + plusRotation, Vector3.forward) * direction;
                var bulletSpawnPoint =  this.transform.position + direction;
                float angle;
                if(direction.x <= 0) {
                    angle = Vector3.Angle(direction, Vector3.up); 
                } else {
                    angle = 360f - Vector3.Angle(direction, Vector3.up);
                }

                
                GameObject pattern = Instantiate(patternPrefab, bulletSpawnPoint, Quaternion.Euler(0, 0, angle));
                pattern.GetComponent<BulletPattern>().setValues(patternSpeed, 0, direction);
            }
    }

}
