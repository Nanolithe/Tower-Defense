using System;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    public int enemyHealth = 15;
    public float speed = 3f;
    private Camera mainCamera;
    public int coins = 50;
    public Image healthBar;

    public List<Transform> waypointList;

    private int targetWaypointIndex;
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public delegate void EnemyDied(EnemyDemo deadEnemy);

    public event EnemyDied OnEnemyDied;
    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        mainCamera = Camera.main;
        // todo #2
        transform.position = waypointList[0].position;
        targetWaypointIndex = 1;
        //   Place our enemy at the starting waypoint
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    
    void Death()
    {
        Economy.Money += coins;
        Destroy(gameObject);
        Debug.Log("You have $" + Economy.Money);
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = waypointList[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        Vector3 newPosition = transform.position;
        newPosition += movementDir * speed * Time.deltaTime;

        transform.position = newPosition;
        // todo #4 Check if destination reaches or passed and change target

        bool enemyDied = false;
        if (enemyDied)
        {
            OnEnemyDied?.Invoke(this);
        }

        if (Vector3.Distance(transform.position, targetPosition) <= 0.2f)
        {
            TargetNextWaypoint();
        }

    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
        if (targetWaypointIndex == waypointList.Count - 1)
        {
            Economy.Lives--;
            Destroy(gameObject);
            Debug.Log("Enemy has been obliterated ");
            return;
        }
        targetWaypointIndex++;
        //transform.position = targetWaypointIndex;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        healthBar.fillAmount = enemyHealth / 10f;
        if (enemyHealth <= 0)
        {
            //Destroy(gameObject);
            Death();
        }
    }
    
}
