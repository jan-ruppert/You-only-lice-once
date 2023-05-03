using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes an item which changes the amount of stamina per dash of the player.
/// </summary>
public class DashStaminaItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseDashStamina(this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
