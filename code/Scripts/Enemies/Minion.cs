using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class implements the behaviour of a minion enemy.
/// </summary>
public class Minion : MonoBehaviour
{
    /// <summary>
    /// The possible colors of the minion.
    /// </summary>
    [Header("Color")]
    [SerializeField]
    private List<Color> colors;
    [Header("Logic")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletForce;
    [SerializeField]
    private float rotateAngle;
    [SerializeField]
    private float shootingTime;
    private float shootingCounter;

    private float plusRotation = 0;
    private CountdownController countdownController;
    private Rigidbody2D rb;
    private Color minionColor;
    
    void Start()
    {
        countdownController = GameObject.FindGameObjectWithTag("General").GetComponent<CountdownController>();
        rb = this.GetComponent<Rigidbody2D>();
        shootingCounter = shootingTime;
        minionColor = colors[Random.Range(0, colors.Count)];
        this.gameObject.GetComponent<SpriteRenderer>().color = minionColor;
    }

    /// <summary>
    /// Implements the shooting countdown and updates the color to its default color.
    /// </summary>
    void Update()
    {
        if(!countdownController.IsCountdownActive) {
            if(shootingCounter > 0) {
                shootingCounter -= Time.deltaTime;
            } else {
                circleShoot();
                shootingCounter = shootingTime;
            }
        }
        if(this.gameObject.GetComponent<SpriteRenderer>().color == Color.white) {
            this.gameObject.GetComponent<SpriteRenderer>().color = minionColor;
        }
    }

    /// <summary>
    /// Initializes bullets around the gameobject in a given rotation and adding them a force.
    /// </summary>
    private void circleShoot() {
        var amount = 4;
        var stepSize = 360f/amount;
        plusRotation = (plusRotation + rotateAngle) % 360;
        for (int i = 0; i < amount; i++) {
            var direction = Vector3.right * GetComponent<Renderer>().bounds.size.x * 1.5f;
            direction = Quaternion.AngleAxis(i * stepSize + plusRotation, Vector3.forward) * direction;
            var bulletSpawnPoint =  this.transform.position + direction;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(direction / Vector3.Magnitude(direction) * bulletForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Signals the slime boss that the minion is destroyed.
    /// </summary>
    private void OnDestroy() {
        var enemyStateManager = GameObject.FindGameObjectWithTag("EnemyStateManager");
        if(enemyStateManager != null) {
            if(enemyStateManager.TryGetComponent(out SlimeBossHardSM enemyState))
                enemyStateManager.GetComponent<SlimeBossHardSM>().removeMinion(); 
            if(enemyStateManager.TryGetComponent(out SlimeBossMediumSM first))
                enemyStateManager.GetComponent<SlimeBossMediumSM>().removeMinion();
            if(enemyStateManager.TryGetComponent(out SlimeBossUnlimitSM unlimit))
                enemyStateManager.GetComponent<SlimeBossUnlimitSM>().removeMinion();  
        }
    }
}