using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class implements the functionality of the UI health bar.
/// </summary>
public class HPBar : MonoBehaviour
{
    public Slider hpBar;

    private int maxHealth;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<Player>();
        maxHealth = PlayerStats.maxHealth;
        hpBar.maxValue = maxHealth;
        hpBar.value = maxHealth;
    }

    /// <summary>
    /// Updates the value of the hpBar slider.
    /// </summary>    
    void Update()
    {
        hpBar.value = player.getHealth();
    }
}
