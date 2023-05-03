using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the shooting of a snake part.
/// </summary>
public class PartShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletForce;
    [SerializeField]
    private float shootingTime;
    private float shootingCounter;
    private CountdownController countdownController;

    private void Start() {
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
    }

    /// <summary>
    /// Counts the shootingCounter down, if its greater 0 and shoots 2 times and resets shootingCounter otherwise.
    /// </summary>
    void Update()
    {
        if(!countdownController.IsCountdownActive) {
            if(shootingCounter > 0) {
                shootingCounter -= Time.deltaTime;
            } else {
                Shoot(2);
                shootingCounter = shootingTime;
            }
        }
    }

    /// <summary>
    /// Instantiates numberBullets bullet prefabs and adds them a force in a random direction.
    /// </summary>
    /// <param name="numberBullets">Number of bullets to instantiate.</param>
    private void Shoot(int numberBullets) {
        for(int i = 0; i < numberBullets; i++) {
            var direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0) * GetComponent<Renderer>().bounds.size.x * 1.5f;
            var bulletSpawnPoint =  this.transform.position + direction;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(direction / Vector3.Magnitude(direction) * bulletForce, ForceMode2D.Impulse);
        }
    }
}
