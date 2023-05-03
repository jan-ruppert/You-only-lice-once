using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes an item which changes the bullet-speed of the player.
/// </summary>
public class BulletSpeedItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseBulletSpeed(this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
