using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the state of the slime boss where he shoots bullet patterns in a circle.
/// </summary>
public class TriangleState : State
{
    [SerializeField]
    private GameObject patternPrefab;

    [SerializeField]
    private float patternSpeed;
    [SerializeField]
    private float shootingTime;
    [SerializeField]
    private int patternAmount;
    [SerializeField]
    private float addRotation = 2;

    private GameObject enemy;
    private float plusRotation = 0;
    private float shootingCounter;
    private bool canShoot = false;


    private void Start() {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update() {
        if(shootingCounter < 0) {
            canShoot = true;
        } else {
            shootingCounter -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Initializes bullet patterns around the gameobject in a given rotation and adding them a speed and rotation value.
    /// </summary>
    public override void Execute() {
        if(canShoot) {
            var stepSize = 360f/patternAmount;
            plusRotation = (plusRotation + addRotation) % 360;
            for (int i = 0; i < patternAmount; i++) {
                var direction = Vector3.right * enemy.GetComponent<Renderer>().bounds.size.x * 2f;
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
            shootingCounter = shootingTime;
            canShoot = false;
        }
    }
}