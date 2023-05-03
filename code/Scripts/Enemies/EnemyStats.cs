/// <summary>
/// This static class saves the enemy stats for the unlimit versions.
/// </summary>
public static class EnemyStats
{
    public const int defaultSlimeHealth = 200;

    public const int defaultSnakeHealth = 200;

    public const int healthIncreaseAmount = 50;

    public static int SlimeHealth = defaultSlimeHealth;

    public static void increaseFBHealth() {
        SlimeHealth += healthIncreaseAmount;
    }

    public static void increaseSBHealth() {
        SlimeHealth += healthIncreaseAmount;
    }
}
