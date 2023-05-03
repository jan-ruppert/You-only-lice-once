using UnityEngine.SceneManagement;

/// <summary>
/// This class describes an item which changes the amount of stamina, which is used while the player is running.
/// </summary>
public class RunStaminaItem : Item
{
    /// <summary>
    /// Applies the increase of the item value and the new multiplier
    /// </summary>
    public override void applyItem()
    {
        PlayerStats.increaseRunStamina(this.amount);
        Score.multiplicateMultiplier(this.multiplier);
    }
}
