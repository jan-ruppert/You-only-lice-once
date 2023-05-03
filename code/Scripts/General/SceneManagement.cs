using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This static class saves the indices of the scenes and manages the next loaded scene.
/// </summary>
public static class SceneManagement
{   
    public const int MainMenu = 0;
    public const int ItemSelectScene = 1;
    public const int FirstBossEasy = 2;
    public const int FirstBossMed = 3;
    public const int FirstBossHard = 4;
    public const int SecondBossEasy = 5;
    public const int SecondBossMedium = 6;
    public const int SecondBossHard = 7;
    public const int FirstBossUnlimit = 8;
    public const int Tutorial = 9;


    private static int currentBoss = FirstBossEasy;

    public static int getStartBoss() {
        return FirstBossEasy;
    }

    public static int getNextBoss() {
        updateCurrentBoss();
        return currentBoss;
    }

    public static void resetBoss() {
        currentBoss = FirstBossEasy;
    }

    private static void updateCurrentBoss() {
        if (currentBoss < 8) {
            currentBoss++;
        } else if (currentBoss == 8) {
            currentBoss = 8;
        }
    }
}
