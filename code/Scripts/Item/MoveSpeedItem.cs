using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes an item which changes the movement speed of the player.
/// </summary>
public class MoveSpeedItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseMoveSpeed(this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
