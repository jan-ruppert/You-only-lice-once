using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the fight tutorial.
/// </summary>
public class TutFightState : TutorialState
{
    [Header("GameLogic")]
    /// <summary>
    /// Prefab of the tutorial enemy.
    /// </summary>
    [SerializeField]
    private GameObject tutEnemyPrefab;
    private bool spawned = false;
    private GameObject tutEnemy;

    /// <summary>
    /// Instantiates the enemy object.
    /// </summary>
    public override void Execute()
    {
        if(description.GetComponent<Dialogue>().Done && !spawned) {
            Instantiate(tutEnemyPrefab, this.transform.position, Quaternion.identity);
            spawned = true;
        }
    }

    /// <summary>
    /// Marks the tutorial part as done.
    /// </summary>
    public void Finished(){
        this.done = true;
    }
}
