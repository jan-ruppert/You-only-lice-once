using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes an item which changes the fire-rate of the player.
/// </summary>
public class FireRateItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseFireRate(this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
