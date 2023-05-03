using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the state of the slime boss where he shoots in a spiral.
/// </summary>
public class SpiralShootState : State
{
    [SerializeField]
    private float addRotation = 2;
    [SerializeField]
    private int bulletAmount = 6;
    [SerializeField]
    private float bulletForce = 10f;
    [SerializeField]
    private float shootingTime;
    [SerializeField]
    private GameObject bulletPrefab;
    
    private float plusRotation = 0;
    private float shootingCounter;
    private bool canShoot = false;
    private GameObject enemy;

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
    /// Initializes bullets around the gameobject in a given rotation and adding them a force.
    /// </summary>
    public override void Execute()
    {
        if(canShoot) {
            var stepSize = 360f/bulletAmount;
            plusRotation = (plusRotation + addRotation) % 360;
            for (int i = 0; i < bulletAmount; i++) {
                var direction = Vector3.right * enemy.GetComponent<Renderer>().bounds.size.x * 1.1f;
                direction = Quaternion.AngleAxis(i * stepSize + plusRotation, Vector3.forward) * direction;
                var bulletSpawnPoint =  this.transform.position + direction;
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint, Quaternion.identity);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(direction / Vector3.Magnitude(direction) * bulletForce, ForceMode2D.Impulse);
            }
            shootingCounter = shootingTime;
            canShoot = false;
        }
        
    }
}
