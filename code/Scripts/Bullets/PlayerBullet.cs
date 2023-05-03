using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the bullet shot by the player.
/// </summary>
public class PlayerBullet : MonoBehaviour
{
    /// <summary>
    /// General particle effect.
    /// </summary>
    [SerializeField]
    private GameObject particleEffect;
    /// <summary>
    /// Particle effect, if enemy is hit.
    /// </summary>
    [SerializeField]
    private GameObject scoreEffect;
    private int bulletDamage;
    private CameraShake cameraShake;

    private void Start() {
        bulletDamage = PlayerStats.bulletDamage;
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    /// <summary>
    /// If a bullet collides with an Enemy-tagged object the score increases, the enemy object takes damage and the camera starts shaking.
    /// The bullet game object is always destroyed and instantiates a particle effect at its last position. 
    /// </summary>
    /// <param name="collision">Collision details returned by 2D physics callback functions. https://docs.unity3d.com/ScriptReference/Collision2D.html</param>
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Enemy") {
            Score.addShootScore();
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            StartCoroutine(cameraShake.Shake(0.01f, 0.1f));
            Instantiate(scoreEffect, this.transform.position, Quaternion.identity);
        } else {
            Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
