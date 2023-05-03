using UnityEngine.SceneManagement;

/// <summary>
/// This class describes an item which changes the maximum amount of health of the player.
/// </summary>
public class MaxHealthItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseMaxHealth((int) this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}