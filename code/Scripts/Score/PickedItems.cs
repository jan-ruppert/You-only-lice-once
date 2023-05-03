using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the picked items by the player and resets them after each run.
/// </summary>
public static class PickedItems
{
    public static List<Item> items = new List<Item>();

    public static void reset() {
        items = new List<Item>();
    }
}
