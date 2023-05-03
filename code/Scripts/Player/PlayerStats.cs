/// <summary>
/// This class saves the default player stats and the stats of the current run.
/// </summary>

public static class PlayerStats
{
    //the default playerStats
    public const float defWalkSpeed = 6f;

    public const int defRunSpeedMulti = 2;

    public const float defRunStamina = 5f;

    public const int defBulletDamage = 2;

    public const int defMaxHealth = 150;

    public const int defMaxStamina = 100;

    public const float defStaminaRegenAmount = 1f;

    public const float defDashStamina = 10f;

    public const int defBulletSpread = 15;

    public const float defFireRate = 0.1f;

    public const float defBulletSpeed = 20f;

    public static float walkSpeed = defWalkSpeed;

    public static float runSpeed = defWalkSpeed * defRunSpeedMulti;

    public static float runStamina = defRunStamina;

    public static int bulletDamage = defBulletDamage;

    public static int maxHealth = defMaxHealth;

    public static int maxStamina = defMaxStamina;

    public static float staminaRegenAmount = defStaminaRegenAmount;

    public static float dashStamina = defDashStamina;

    public static int bulletSpread = defBulletSpread;

    public static float fireRate = defFireRate;

    public static float bulletSpeed = defBulletSpeed;

    /// <summary>
    /// Resets the player stats to default.
    /// </summary>
    public static void reset() {
        walkSpeed = defWalkSpeed;
        runSpeed = defWalkSpeed * defRunSpeedMulti;
        runStamina = defRunStamina;
        bulletDamage = defBulletDamage;
        maxHealth = defMaxHealth;
        maxStamina = defMaxStamina;
        staminaRegenAmount = defStaminaRegenAmount;
        dashStamina = defDashStamina;
        bulletSpread = defBulletSpread;
        fireRate = defFireRate;
        bulletSpeed = defBulletSpeed;
    }
    public static void increaseMoveSpeed(float amount) {
        if(walkSpeed + amount > 1f)
            walkSpeed += amount;
            runSpeed = walkSpeed * defRunSpeedMulti;
    }

    public static void increaseRunStamina(float amount) {
        if(runStamina + amount > 1f)
            runStamina += amount;
    }

    public static void increaseBulletDamage(int amount) {
        if(bulletDamage + amount > 1f)
            bulletDamage += amount;
    }
    public static void increaseMaxHealth(int amount) {
        if(maxHealth + amount > 1f)
            maxHealth += amount;
    }

    public static void increaseMaxStamina(int amount) {
        if(maxStamina + amount > 1f)
            maxStamina += amount;
    }

    public static void increaseBulletSpread(int amount) {
        if(bulletSpread + amount > 1f)
            bulletSpread += amount;
    }

    public static void increaseFireRate(float amount) {
        if(fireRate + amount > 0.001f)
            fireRate += amount;
    }

    public static void increaseBulletSpeed(float amount) {
        if(bulletSpeed + amount > 0)
            bulletSpeed += amount;
    }

    public static void increaseDashStamina(float amount) {
        if(dashStamina + amount > 0)
            dashStamina += amount;
    }

    public static void increaseStaminaRegenAmount(float amount) {
        if(staminaRegenAmount + amount > 1)
            staminaRegenAmount += amount;
    }
}
