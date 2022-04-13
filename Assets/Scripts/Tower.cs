using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Tower : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public float damagePerSecond = 1f;
    private float damagePerSecondTimer = 0f;
    public GameObject arrowPrefab;
    public Transform arrowReleasePoint;
        

    // Start is called before the first frame update
    void Start()
    {
        //Checks the function twice per second
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            //find enemy and label enemy as shortest
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (damagePerSecondTimer <= 0f)
        {
            Shoot();
            damagePerSecondTimer = 1f / damagePerSecond;
        }

        damagePerSecondTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, arrowReleasePoint.position, arrowReleasePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();

        if (arrow != null)
        {
            arrow.Seek(target);
            //Debug.Log("Enemy has" + target);
            //target.GetComponent<EnemyDemo>().TakeDamage(1);

            //Debug.Log("Enemy has" + EnemyDemo.enemyHealth);
        }

        if (arrow == null)
        {
            //target.GetComponent<EnemyDemo>().TakeDamage(1);
        }
    }
}
