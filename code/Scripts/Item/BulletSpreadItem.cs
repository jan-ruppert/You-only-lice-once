using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes an item which changes the bullet-spread of the player.
/// </summary>
public class BulletSpreadItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseBulletSpread((int) this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
