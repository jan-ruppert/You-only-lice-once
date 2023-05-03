using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of a bullet.
/// </summary>

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected int bulletDamage;
    [Header("Particles")]
    /// <summary>
    /// General particle effect.
    /// </summary>
    [SerializeField]
    protected GameObject particleEffect;
    /// <summary>
    /// Particle effect, if player is hit.
    /// </summary>
    [SerializeField]
    protected GameObject playerHitPE;
    protected CameraShake cameraShake;

    private void Start() {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    /// <summary>
    /// If a bullet collides with an PlayerBody-tagged object the score increases, the player object takes damage and the camera starts shaking.
    /// The bullet game object is always destroyed and instantiates a particle effect at its last position. 
    /// </summary>
    /// <param name="other">Collision details returned by 2D physics callback functions. https://docs.unity3d.com/ScriptReference/Collision2D.html</param>
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "PlayerBody") {
            other.gameObject.GetComponent<Player>().takeDamage(bulletDamage);
            Instantiate(playerHitPE, this.transform.position, Quaternion.identity);
            StartCoroutine(cameraShake.Shake(0.01f, 0.2f));
        } else {
            Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
