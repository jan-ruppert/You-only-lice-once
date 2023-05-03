using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the state manager of the unlimited (hardest) version of the slime boss.
/// </summary>
public class SlimeBossUnlimitSM : MonoBehaviour
{
    private State currentState;
    [SerializeField]
    private StunState stunState;
    [SerializeField]
    private CircleShootState circleShootState;
    [SerializeField]
    private SpawnState spawnState;
    [SerializeField]
    private SpiralShootState spiralShootState;
    [SerializeField]
    private ReversedSpiralShootState reversedSpiralShootState;
    [SerializeField]
    private PatternState patternState;
    [SerializeField]
    private TriangleState triangleState;
    [SerializeField]
    private DeathState deathState;


    [SerializeField]
    private float circleShootRange;
    [SerializeField]
    private float stunTime;
    [SerializeField]
    private int numberMinions;
    [SerializeField]
    private int remainingMinions;

    private float stunCountDown;

    private float patternCountdown;

    private GameObject player;
    private GameObject enemy;
    private CountdownController countdownController;

    private GameObject shield;

    void Start()
    {
        
        stunCountDown = 0;
        patternCountdown = Random.Range(2, 10);
        currentState = spawnState;
        player = GameObject.FindGameObjectWithTag("PlayerBody");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy.GetComponent<Enemy>().setMaxHealth(EnemyStats.SlimeHealth);
        shield = enemy.transform.GetChild(0).gameObject;
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
        ResetMinionsNumber();
    }

    /// <summary>
    /// Updates current state and resizes the slime.
    /// </summary>
    void Update()
    {   
        var currentHealth = enemy.GetComponent<Enemy>().getCurrentHealth();
        
        if(currentHealth <= 0) {
            EnemyStats.increaseFBHealth();
            deathState.Execute();
        }

        
        if(enemy.GetComponent<Enemy>().getMaxHealth() > 0) {
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

        //Enemy is stunned while the countdown is active
        if(countdownController.IsCountdownActive){
            return stunState;
        }
            

        if(stunCountDown > 0) {
            stunCountDown -= Time.deltaTime;
            return stunState;
        }

        if(remainingMinions == 0 && currentState == stunState) {
            ResetMinionsNumber();
            shield.SetActive(true);
            return spawnState;
        }

        if(remainingMinions == 0) 
        {   
            stunCountDown = stunTime;
            shield.SetActive(false);
            return stunState;
        } 

        if(patternCountdown <= 0) {
            patternCountdown = Random.Range(2, 10);
            return patternState;
        } else {
            patternCountdown -= Time.deltaTime;
        }

        if(distance <= circleShootRange) {
            return circleShootState;
        } else {
            float enemyHealthPercent = (float) enemy.GetComponent<Enemy>().getCurrentHealth() / (float) enemy.GetComponent<Enemy>().getMaxHealth();

            if(enemyHealthPercent <= 0.25) {
                return triangleState;
            } else {
                if(remainingMinions % 2 == 0)
                    return spiralShootState;
                else
                    return reversedSpiralShootState;
            }
        }    
    }

    /// <summary>
    /// Resets the number of minions.
    /// </summary>
    public void ResetMinionsNumber() {
        remainingMinions = numberMinions; 
    }

    /// <summary>
    /// Decreasing the number of minions by 1.
    /// </summary>
    public void removeMinion() {
        remainingMinions--;
    }
}
