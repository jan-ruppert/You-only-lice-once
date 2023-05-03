using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class describes an item which changes the bullet-damage of the player.
/// </summary>
public class BulletDamageItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseBulletDamage((int) this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
