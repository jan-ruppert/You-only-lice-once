using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class implements the functionality of the UI stamina bar.
/// </summary>
public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina;
    private float currentStamina;

    /// <summary>
    /// The amount of stamina regenerated per tick.
    /// </summary>
    private float regenAmount;

    /// <summary>
    /// The time between to ticks.
    /// </summary>
    /// <returns></returns>
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        maxStamina = PlayerStats.maxStamina;
        regenAmount = PlayerStats.staminaRegenAmount;
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    /// <summary>
    /// Implements the usage of stamina by reducing the currentStamina amount by a given amount if currentStamina is greater or equals amount.
    /// </summary>
    /// <param name="amount">The amount of stamina that is used.</param>
    public void useStamina(float amount)
    {
        if(currentStamina  - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
        } else
        {
            Debug.Log("Not enough Stamina");
        }
    }

    public void setStamina(float stamina)
    {
        if(stamina >= 0)
        {
            currentStamina = stamina;
            staminaBar.value = currentStamina;
            
            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    public float getStamina()
    {
        return currentStamina;
    }

    /// <summary>
    /// Implements regenerating stamina over time by adding a given amount of stamina per tick.
    /// </summary>
    /// <returns></returns>
    public IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);
        while(currentStamina < maxStamina)
        {
            currentStamina += regenAmount;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
}
