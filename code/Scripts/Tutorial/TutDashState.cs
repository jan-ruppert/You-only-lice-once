using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the dash tutorial.
/// </summary>
public class TutDashState : TutorialState
{
    [Header("GameLogic")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletForce;
    /// <summary>
    /// The time between spawning bullets.
    /// </summary>
    [SerializeField]
    private float shootingTime;
    /// <summary>
    /// The time the player has to survive without a hit to complete the dash tutorial.
    /// </summary>
    [SerializeField]
    private float surviveTime;
    private float surviveCounter;
    private float shootingCounter;
    private bool canShoot = false;
    private bool startCounter = false;

    private void Start() {
        surviveCounter = surviveTime;
    }

    /// <summary>
    /// Updates and resets the shooting and survive counter
    /// </summary>
    private void Update() {
        if(shootingCounter < 0) {
            canShoot = true;
        } else {
            shootingCounter -= Time.deltaTime;
        }
        if(startCounter) {
            if (surviveCounter < 0) {
                this.done = true;
            } else {
                Debug.Log(surviveCounter);
                surviveCounter -= Time.deltaTime;
            }
        }        
    }
    
    /// <summary>
    /// Spawns bullets with given force the player has to dodge.
    /// </summary>
    public override void Execute()
    {
        if(description.GetComponent<Dialogue>().Done) {
            startCounter = true;
            if(canShoot) {
                for(int i = -23; i <= 23; i++) {
                    var bulletSpawnPoint =  this.transform.position + new Vector3(i, 0, 0);
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint, Quaternion.identity);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(Vector2.down * bulletForce, ForceMode2D.Impulse);
                }
                shootingCounter = shootingTime;
                canShoot = false;
            }
        }
    }

    /// <summary>
    /// Resets the survive counter.
    /// </summary>
    public void ResetTime() {
        surviveCounter = surviveTime;
    }
}
