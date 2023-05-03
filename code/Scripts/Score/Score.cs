using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This static class manages the score system by saving and resetting the score as well as saving the highscore.
/// </summary>
public static class Score {

    public const float defaultMultiplier = 1f;

    public const int defaultPlayerScore = 0;

    public const int defaultStagesCompleted = 0;

    public const int defaultScorePerHit = 10;

    public const int scorePerHealthPoint = 5;

    public static int PlayerScore;

    public static int HighScore;

    public static int StagesCompleted;

    public static int HighStages;

    public static float Multiplier = defaultMultiplier;

    public static int scorePerHit = defaultScorePerHit;

    public static void addShootScore() {
        var temp = scorePerHit * Multiplier;
        PlayerScore += (int) temp;
    }

    public static void addHealthScore(int hp) {
        PlayerScore += scorePerHealthPoint * hp;
    }

    public static void multiplicateMultiplier(float amount) {
        Multiplier *= amount;
    }

    public static void safeHighScore() {
        if(PlayerScore > HighScore)
            HighScore = PlayerScore;
            PlayerPrefs.SetInt("Highscore", HighScore);
    }

    public static void resetScore() {
        PlayerScore = defaultPlayerScore;
        Multiplier = defaultMultiplier;
        StagesCompleted = defaultStagesCompleted;
    }

    public static void resetHighscore() {
        HighScore = defaultPlayerScore;
    }
}
