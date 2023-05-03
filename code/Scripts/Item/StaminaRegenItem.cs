using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes an item which changes the maximum amount of health of the player.
/// </summary>
public class StaminaRegenItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseStaminaRegenAmount(this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
