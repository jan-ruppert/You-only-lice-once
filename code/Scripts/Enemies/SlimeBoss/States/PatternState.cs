using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the state of the slime boss where he shoots bullet patterns.
/// </summary>
public class PatternState : State
{
    private GameObject enemy;

    [SerializeField]
    private GameObject patternPrefabUp;
    [SerializeField]
    private GameObject patternPrefabDown;
    [SerializeField]
    private GameObject patternPrefabLeft;
    [SerializeField]
    private GameObject patternPrefabRight;

    [SerializeField]
    private float patternSpeed;

    [SerializeField]
    private float patternRotation;

    private float enemyBounds;
    private void Start() {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyBounds = enemy.GetComponent<Renderer>().bounds.size.x * 5f;
    }

    /// <summary>
    /// Instantiates bullet patterns in four directions.
    /// </summary>
    public override void Execute() {
        GameObject patternRight = Instantiate(patternPrefabRight, Vector3.right * enemyBounds, Quaternion.identity);
        patternRight.GetComponent<BulletPattern>().setValues(patternSpeed, patternRotation, Vector3.right);
        
        GameObject patternLeft = Instantiate(patternPrefabLeft, Vector3.left * enemyBounds, Quaternion.identity);
        patternLeft.GetComponent<BulletPattern>().setValues(patternSpeed, patternRotation, Vector3.left);
        
        GameObject patternUp = Instantiate(patternPrefabUp, Vector3.up * enemyBounds, Quaternion.identity);
        patternUp.GetComponent<BulletPattern>().setValues(patternSpeed, patternRotation, Vector3.up);
       
        GameObject patternDown = Instantiate(patternPrefabDown, Vector3.down * enemyBounds, Quaternion.identity);
        patternDown.GetComponent<BulletPattern>().setValues(patternSpeed, patternRotation, Vector3.down);

    }
}
