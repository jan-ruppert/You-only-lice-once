using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the state manager of the easy version of the slime boss.
/// </summary>
public class SlimeBossEasySM : MonoBehaviour
{
    private State currentState;
    [SerializeField]
    private StunState stunState;
    [SerializeField]
    private CircleShootState circleShootState;
    [SerializeField]
    private SpiralShootState spiralShootState;
    [SerializeField]
    private DeathState deathState;

    [SerializeField]
    private float circleShootRange;

    private GameObject player;
    private GameObject enemy;
    private CountdownController countdownController;

    private GameObject shield;

     void Start()
    {
        currentState = stunState;
        player = GameObject.FindGameObjectWithTag("PlayerBody");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        shield = enemy.transform.GetChild(0).gameObject;
        shield.SetActive(false);
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
    }

    /// <summary>
    /// Updates current state and resizes the slime boss.
    /// </summary>
    void Update()
    {   
        var currentHealth = enemy.GetComponent<Enemy>().getCurrentHealth();
        if(currentHealth <= 0) {
            deathState.Execute();
        }

        if(enemy != null && enemy.GetComponent<Enemy>().getMaxHealth() > 0 && currentHealth > 0) {
            var scale = 1.5f + 1.5f * Mathf.Sqrt((float) currentHealth/(float) enemy.GetComponent<Enemy>().getMaxHealth());
            enemy.transform.localScale = new Vector3(scale, scale, 0);
        }

        currentState.Execute();
        currentState = GetNextState();
    }

    /// <summary>
    /// Logic of the state manager.
    /// </summary>
    /// <returns>Next state depending on situation.</returns>
    public State GetNextState() {

        float distance = Vector3.Distance(enemy.gameObject.transform.position.normalized, player.GetComponent<PlayerMovement>().getPosition());

        //first boss is stunned while the countdown is active
        if(countdownController.IsCountdownActive) {
            return stunState;
        }

        if(distance <= circleShootRange) {
            return circleShootState;
        } else {
            return spiralShootState;
        }    
    }
}