using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Subclass of a normal bullet.
/// </summary>
public class TutorialBullet : Bullet
{
    private void Start() {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    /// <summary>
    /// Same behaviour like a Bullet.cs, but resets the timer during tht dash tutorial and does no damage to the player.
    /// </summary>
    /// <param name="other">Collision details returned by 2D physics callback functions. https://docs.unity3d.com/ScriptReference/Collision2D.html</param>
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "PlayerBody") {
            GameObject.FindGameObjectWithTag("TutDash").GetComponent<TutDashState>().ResetTime();
            Instantiate(playerHitPE, this.transform.position, Quaternion.identity);
            StartCoroutine(cameraShake.Shake(0.01f, 0.2f));
        } else {
            Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
