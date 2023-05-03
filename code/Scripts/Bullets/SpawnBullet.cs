using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a subclass of Bullet and describes the behaviour of a spawn bullet.
/// </summary>
public class SpawnBullet : Bullet
{
    [SerializeField]
    private GameObject wagon;

    private SnakeGeneral trainBoss;

    private void Start() {

        trainBoss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<SnakeGeneral>();

    }

    /// <summary>
    /// Same behaviour like a Bullet.cs, but spawns a new part of the second boss.
    /// </summary>
    /// <param name="other">Collision details returned by 2D physics callback functions. https://docs.unity3d.com/ScriptReference/Collision2D.html</param>
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.transform.tag == "PlayerBody") {

            other.gameObject.GetComponent<Player>().takeDamage(bulletDamage);

            if(trainBoss.NumberParts < trainBoss.MaxNrParts) {

                var newWagon = Instantiate(wagon, Vector3.zero, Quaternion.identity);

                trainBoss.LastWagon.transform.GetChild(0).gameObject.SetActive(true);

                newWagon.GetComponent<PartMovement>().FollowingObject = trainBoss.LastWagon;

                newWagon.GetComponent<PartGeneral>().PartBlink(3);

                trainBoss.LastWagon = newWagon; 

                trainBoss.addPart();
            }
            Instantiate(playerHitPE, this.transform.position, Quaternion.identity);
        } else {
            Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
