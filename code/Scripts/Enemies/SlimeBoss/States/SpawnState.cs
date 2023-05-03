using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the state of the slime boss where he spawns new minions.
/// </summary>
public class SpawnState : State
{
    [SerializeField]
    private List<GameObject> minionSpawnPoints = new List<GameObject>();
    [SerializeField]
    private GameObject minion;

    public override void Execute()
    {
        foreach(GameObject spawnPoint in minionSpawnPoints) {
            Instantiate(minion, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
