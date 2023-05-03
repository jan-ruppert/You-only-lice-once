using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the general behaviour of an enemy.
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    [Header("Particles")]
    [SerializeField]
    private GameObject particleEffect;

    private int currentHealth;
    private void Start() {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Destroys the gameobject, if the currentHealth is equal or less then 0.
    /// </summary>
    private void Update() {
        if(currentHealth <= 0) {
            Instantiate(particleEffect, this.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }

    /// <summary>
    /// Removes given amount of health.
    /// </summary>
    /// <param name="damage">How much the current health is reduced.</param>
    public void TakeDamage(int damage) {
        currentHealth -= damage;
        StartCoroutine(ChangeColor(gameObject));
    }

    /// <summary>
    /// Changes the color of the game object for a short amount of time to red.
    /// </summary>
    /// <param name="gameObject">The gameobject which color is changed.</param>
    /// <returns></returns>
    IEnumerator ChangeColor(GameObject gameObject) {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public int getMaxHealth() {
        return maxHealth;
    }

    public void setMaxHealth(int amount) {
        maxHealth = amount;
        currentHealth = amount;
    }

    public int getCurrentHealth() {
        return currentHealth;
    }
}
